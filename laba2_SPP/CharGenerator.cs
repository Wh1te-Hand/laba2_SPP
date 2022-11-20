using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba2_SPP
{
    public class CharGenerator:IGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var random = new Random();
            char result = (char)0;
            while (result == 0)
            {
                result = (char)random.Next(char.MinValue, char.MaxValue);
            }
            return result;
        }

        public Type getGeneratedType(Type type)
        {
            return type=typeof(char);
        }
    }
}
