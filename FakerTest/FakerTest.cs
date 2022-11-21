using laba2_SPP;
using Microsoft.VisualBasic;

namespace FakerTest
{
    [TestClass]
    public class FakerTest
    {
        private Faker faker = new Faker();
        private struct _Struct
        {
            public int A;
            public float B;
        }
        private class A
        {
            public B b;
        }
        private class B
        {
            public A a;
        }
        class ClassWithInnerClass
        {
            public int A;
            public AllTypes allTypes;
        }
        public class AllTypes
        {
            public int I;
            public float f;
            public char C;
            public string S;
        }

        [TestMethod]
        public void GenerateByte()
        {
            byte byteV = faker.Create<byte>();
            Assert.AreNotEqual(byteV , 0);
        }
        [TestMethod]
        public void GenerateDate()
        {            
            DateTime date = faker.Create<DateTime>();
            Assert.AreNotEqual(date , null);
        }
        [TestMethod]
        public void GenerateInt()
        {
            int intV = faker.Create<int>();
            Assert.AreNotEqual(intV , 0);
        }
        [TestMethod]
        public void GenerateString()
        {
          
            string str = faker.Create<string>();
            Assert.AreNotEqual(str ,null);
        }

        [TestMethod]
        public void GenerateChar()
        {
            char charV = faker.Create<char>();
            Assert.AreNotEqual(charV ,Convert.ToChar(0));
        }

        [TestMethod]
        public void GenerateFloat()
        {
            float floatV = faker.Create<float>();
            Assert.AreNotEqual(floatV , 0);
        }

        [TestMethod]
        public void GenerateDouble()
        {
            double doubleV = faker.Create<double>();
            Assert.AreNotEqual(doubleV ,0) ;
        }

        [TestMethod]
        public void GenerateClassWithInnerClass()
        {
            ClassWithInnerClass C = faker.Create<ClassWithInnerClass>();
            Assert.AreNotEqual(C.A ,0);
            Assert.AreNotEqual(C.allTypes.I ,0);
            Assert.AreNotEqual(C.allTypes.C , 0);
            Assert.AreNotEqual(C.allTypes.f , 0);
            Assert.AreNotEqual(C.allTypes.S ,null);
        }

        [TestMethod]
        public void GenerateRecursion()
        {
            A a = faker.Create<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.b);
            Assert.IsNull(a.b.a);
        }


        [TestMethod]
        public void GenerateStruct()
        {
            _Struct _struct = faker.Create<_Struct>();
            Assert.AreNotEqual(_struct.A , 0);
            Assert.AreNotEqual(_struct.B , 0);
        }
    }
}