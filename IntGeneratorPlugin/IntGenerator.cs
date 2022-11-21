using laba2_SPP;

namespace IntGeneratorPlugin
{
    public class IntGenerator:IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            int result = 0;
            while (result == 0)
            {
                result = (int)random.Next(int.MinValue, int.MaxValue);
            }
            return result;
        }

        public Type getGeneratedType()
        {
            return  typeof(int);
        }

    }
}