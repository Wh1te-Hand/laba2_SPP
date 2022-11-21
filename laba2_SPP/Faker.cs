using laba2_SPP.Generators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public class Faker : IFaker
    {
        private readonly Dictionary<Type, IGenerator> generators;
        private GeneratorContext generatorContext;

        public Faker()
        {
            generators = GetGenerators();
           // generatorContext = new GeneratorContext(new Random(), this);
        }

        private void ConnectDll(Dictionary<Type, IGenerator> generators)
        {
            string pathToDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Plugins\\");
            string[] allDll = Directory.GetFiles(pathToDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type);
                        generators.Add(g.getGeneratedType(), g);
                    }
                }
            }
        }
        private Dictionary<Type, IGenerator> GetGenerators()
        {
           Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>() {
                { typeof(string),new StringGenerator() },
                { typeof(byte),new ByteGenerator() },
                { typeof(char),new CharGenerator() },
                { typeof(float),new FloatGenerator()},
                { typeof(DateTime),new DateGenerator()}
                 };
            ConnectDll(generators);
            return generators;
        }

        public bool AddGenerator(KeyValuePair<Type, IGenerator> generator)
        {
            if (generators.ContainsKey(generator.Key))
                return false;
            generators.Add(generator.Key, generator.Value);
            return true;
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type t)
        {
            generators.TryGetValue(t, out var generator);
            if (generator == null)
            {
                generator = (t.IsGenericType) ? generators[typeof(List<>)] : generators[typeof(object)];
            }
            if (generator.getGeneratedType() == null)
                throw new FakerException($"Cannot generate for type {t.Name}");
            return generator.Generate();
        }
    }
}
