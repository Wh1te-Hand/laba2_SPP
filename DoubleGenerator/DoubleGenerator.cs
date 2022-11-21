

using laba2_SPP;

namespace  DoubleGeneratorPlugin
{
    public class DoubleGenerator: IGenerator
    {
        public object Generate()
        {
            Faker faker=new Faker();
            var random=new Random();
            return (double)(random.NextDouble() + (double)faker.Create<byte>());
        }
        public Type getGeneratedType()
        {
            return typeof(double);
        }
    }
}

