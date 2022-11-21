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

        public object Generate()
        {
            var random=new Random();
            Faker faker = new Faker();
            int len = random.Next(1, Limit);
            var result = new StringBuilder(len);

            for (int i = 0; i < len; i++)
                result.Append(chars[random.Next(0,chars.Length-1)]);
            return result.ToString();
        }
        public Type getGeneratedType()
        {
            return typeof(string);
        }
    }
}
