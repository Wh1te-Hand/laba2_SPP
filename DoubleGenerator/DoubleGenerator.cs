

using laba2_SPP;

namespace  DoubleGeneratorPlugin
{
    public class DoubleGenerator: IGenerator
    {
        public Type getGeneratedType(Type type)
        {
            return type = typeof(double);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            Faker faker=new Faker();
            return (double)(context.Random.NextDouble() + (double)faker.Create<byte>());
        }
    }
}

