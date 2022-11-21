using laba2_SPP;

namespace IntGeneratorPlugin
{
    public class IntGenerator:IGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var random = new Random();
            int result = 0;
            while (result == 0)
            {
                result = (int)random.Next(int.MinValue, int.MaxValue);
            }
            return result;
        }

        public Type getGeneratedType(Type type)
        {
            return type = typeof(int);
        }

    }
}