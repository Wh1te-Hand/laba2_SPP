using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public class FakerException:Exception
    {
        public override string Message { get; }

        public FakerException(string message) => Message = $"FakerException: {message}";
    }
}
