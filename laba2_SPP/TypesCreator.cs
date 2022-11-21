using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using laba2_SPP.Generators;

namespace laba2_SPP
{
    public class TypesCreator
    {
        private Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>();

    /*    public TypesCreator()
        {
            try
            {
                LoadExistingGenerators();
 //               LoadAdvancedGenerators();
            }
            catch
            {
                // nothing to load
            }
        }


        private void LoadExistingGenerators()
        {
            IGenerator byteG = new ByteGenerator();
            generators.Add(byteG.getGeneratedType(typeof(Byte)), byteG);

            IGenerator intG = new IntGenerator();
            generators.Add(intG.getGeneratedType(typeof(int)), intG);

            IGenerator charG = new CharGenerator();
            generators.Add(charG.getGeneratedType(typeof(char)), charG);
        }*/



        public bool GeneratorExists(Type type)
        {
            if (generators.ContainsKey(type))
            {
                return true;
            }
            return false;
        }

        public object Create(Type type)
        {
            return generators[type].Generate(type,null);
        }
    }
}
