using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP.Generators
{
    public class FloatGenerator : IGenerator
    {
        public Type getGeneratedType(Type type)
        {
            return type = typeof(float);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            Faker faker = new Faker();
            return context.Random.NextSingle() + faker.Create<byte>();
        }
    }
}
