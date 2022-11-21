using laba2_SPP.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
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
            generatorContext = new GeneratorContext(new Random(), this);
        }

        private Dictionary<Type, IGenerator> GetGenerators()
        {
            return new Dictionary<Type, IGenerator>() {
               // { typeof(int),new IntGenerator() },
                { typeof(string),new StringGenerator() },
                { typeof(byte),new ByteGenerator() },
                { typeof(char),new CharGenerator() },
               // { typeof(double),new DoubleGenerator() }, 
                { typeof(float),new FloatGenerator()},
                { typeof(DateTime),new DateGenerator()}
                 };
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
            if (generator.getGeneratedType()==null)
                throw new FakerException($"Cannot generate for type {t.Name}");
            return generator.Generate();
        }
    }
}
