using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public class ByteGenerator:IGenerator
    {
           
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var random = new Random();
            byte result = 0;
            while (result == 0)
            {
                result = (byte)random.Next(byte.MinValue, byte.MaxValue);
            }
            return result;
        }

        public Type getGeneratedType(Type type)
        {
            return type=typeof(byte);
        }
    
}
}
