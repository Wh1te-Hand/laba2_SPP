using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP.Generators
{
    public class StringGenerator : IGenerator
    {
        private readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public int Limit { get; set; } = 50;

        public Type getGeneratedType(Type type)
        {
            return type = typeof(string);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int len = context.Random.Next(1, Limit);
            var result = new StringBuilder(len);

            for (int i = 0; i < len; i++)
                result.Append(chars[context.Random.Next(chars.Length)]);
            return result.ToString();
        }
    }
}
