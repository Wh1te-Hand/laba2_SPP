using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public interface IFaker
    {
        public T Create<T>();

        public object Create(Type t);

        /// <summary>
        /// Add new generator to List of default generators
        /// </summary>
        /// <param name="generator">generator for Faker</param>
        /// <returns>true if generator was added successfully, otherwise false - generator already exists</returns>
        public bool AddGenerator(KeyValuePair<Type, IGenerator> generator);
    }
}
