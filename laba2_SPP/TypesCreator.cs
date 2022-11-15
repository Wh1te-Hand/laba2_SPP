using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba2_SPP
{
    public class TypesCreator
    {
        private Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>();

        public TypesCreator()
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
            generators.Add(byteG.getGeneratedType(), byteG);

            IGenerator intG = new IntGenerator();
            generators.Add(intG.getGeneratedType(), intG);

            IGenerator charG = new CharGenerator();
            generators.Add(charG.getGeneratedType(), charG);
        }


/*        private void LoadAdvancedGenerators()
        {
            string pathToAdvancedGeneratorsDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\lib\\");
            string[] allDll = Directory.GetFiles(pathToAdvancedGeneratorsDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type);
                        generators.Add(g.getGeneratedType(), g);
                    }
                }
            }
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
            return generators[type].Generate();
        }
    }
}
