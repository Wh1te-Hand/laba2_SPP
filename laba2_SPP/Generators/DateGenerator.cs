using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP.Generators
{
    public class DateGenerator : IGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var random = new Random();
            DateTime start = new DateTime(2002, 07, 30);
            return start.AddDays(random.Next((DateTime.Today - start).Days));
        }
        public Type getGeneratedType(Type type)
        {
            return type = typeof(DateTime);
        }
    }
}
