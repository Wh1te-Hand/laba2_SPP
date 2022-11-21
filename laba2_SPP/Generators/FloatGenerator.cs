using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP.Generators
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            Faker faker = new Faker();
            var random = new Random();
            return random.NextSingle()+faker.Create<byte>();
        }
        public Type getGeneratedType()
        {
            return typeof(float);
        }
    }
}
