using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public interface IGenerator
    {
        Type getGeneratedType();
        object Generate();
    }
}

