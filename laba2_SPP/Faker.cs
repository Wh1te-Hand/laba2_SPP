using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public class Faker
    {
        private TypesCreator creator = new TypesCreator();
        private List<Type> innerTypes = new List<Type>();


        public T Create<T>()
        {
            T obj = (T)CreateDTO(typeof(T));
            return obj;
        }

        private object CreateDTO(Type type)
        {
            if (creator.GeneratorExists(type))
            {
                return creator.Create(type);
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
                    var obj = CreateWithConstructor(type);
                    FillDTO(obj);
                    innerTypes.Remove(type);
                    return obj;
                }
            }
        }
        private object CreateWithConstructor(Type type)
        {
            try
            {
                var constructor = type.GetConstructors()[0];
                var constrParams = constructor.GetParameters();
                var createdConstParams = new List<object>();
                if (constrParams.Any())
                {
                    foreach (var constrParam in constrParams)
                    {
                        createdConstParams.Add(CreateDTO(constrParam.ParameterType));
                    }
                }
                return constructor.Invoke(createdConstParams.ToArray());
            }
            catch
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch
                {
                    return null;
                }
            }
        }



        private void FillDTO(object obj)
        {
            if (obj == null) { return; }

            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    var propertyObject = CreateDTO(property.PropertyType);
                    property.SetValue(obj, propertyObject);
                }
            }

            var fields = obj.GetType().GetFields();
            foreach (var field in fields)
            {
                try
                {
                    var fieldObject = CreateDTO(field.FieldType);
                    field.SetValue(obj, fieldObject);
                }
                catch
                {
                    field.SetValue(obj, null);
                }
            }
        }

    }
}
