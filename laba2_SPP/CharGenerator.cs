using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba2_SPP
{
    public class CharGenerator:IGenerator
    {
        private readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var random=new Random();
            char result;
            return result = chars[(int)random.Next(0, chars.Length - 1)];            
        }

        public Type getGeneratedType(Type type)
        {
            return type=typeof(char);
        }
    }
}
