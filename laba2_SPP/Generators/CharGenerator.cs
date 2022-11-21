using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba2_SPP.Generators
{
    public class CharGenerator : IGenerator
    {
        private readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public object Generate()
        {
            var random = new Random();
            char result;
            return result = chars[random.Next(0, chars.Length - 1)];
        }

        public Type getGeneratedType()
        {
            return  typeof(char);
        }
    }
}
