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
        private List<Type> innerTypes = new List<Type>();
        public Faker()
        {
            generators = GetGenerators();
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


        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type type)
        {

            object resultT;
            if (generators.ContainsKey(type))
            {
                resultT = generators[type].Generate();
            }
            else
            {
                if (type.IsGenericType)
                {
                    var genericType = type.GetGenericArguments()[0];
                    var listType = typeof(List<>).MakeGenericType(genericType);
                    var list = (IList)Activator.CreateInstance(listType);
                    for (int i = 0; i < 10; i++)
                    {
                        list.Add(Create(genericType));
                    }
                    resultT = Convert.ChangeType(list, listType);
                }
                else
                {
                    if (innerTypes.Contains(type))
                    {
                        return null;
                    }
                    else
                    {
                        innerTypes.Add(type);
                        resultT = CreateObject(type);
                        FillFieldsAndProperties(resultT);
                        innerTypes.Remove(type);
                    }
                }
            }
            return resultT;
        }

        private object CreateObject(Type type)
        {
            try
            {
                var constructor = Constructor(type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));
                var constructorParameters = constructor.GetParameters();
                List<object> parameters = new List<object>();

                if (constructorParameters.Any())
                {
                    foreach (var parameter in constructorParameters)
                    {
                        parameters.Add(Create(parameter.ParameterType));
                    }
                }
                return constructor.Invoke(parameters.ToArray());
            }
            catch
            {
                return Activator.CreateInstance(type);
            }
        }

        private ConstructorInfo? Constructor(ConstructorInfo[] constructors)
        {
            if (constructors.Length > 1)
            {
                var AllConstructors =
                constructors.OrderByDescending(ob => ob.GetParameters().Count()).ToList();
                return AllConstructors[0];
            }
            else return constructors.First();
        }
        private void FillFieldsAndProperties(object resultT)
        {
            var type = resultT.GetType();
            var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Static |
               BindingFlags.Instance);

            foreach (var field in publicFields)
            {
                try
                {
                    field.SetValue(resultT, Create(field.FieldType));
                }
                catch
                {
                    field.SetValue(resultT, null);
                }
            }

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    try
                    {
                        property.SetValue(resultT, Create(property.PropertyType));
                    }
                    catch
                    {
                        property.SetValue(resultT, null);
                    }
                }
            }
        }
    }
}

