using laba2_SPP;

class Program
{
    static void Main(string[] args)
    {  
        Faker faker = new Faker();

        byte byteValue = faker.Create<byte>();
        Console.WriteLine("{0}: {1}", byteValue.GetType(), byteValue);

        int intValue = faker.Create<int>();
        Console.WriteLine("{0}: {1}", intValue.GetType(), intValue);

        int charValue = faker.Create<char>();
        Console.WriteLine("{0}: {1}", charValue.GetType(), charValue);

        string stringValue = faker.Create<string>();
        Console.WriteLine("{0}: {1}", stringValue.GetType(), stringValue);

       double doubleValue = faker.Create<double>();
        Console.WriteLine("{0}: {1}", doubleValue.GetType(), doubleValue);

        double floatValue = faker.Create<float>();
        Console.WriteLine("{0}: {1}", floatValue.GetType(), floatValue);

        DateTime DateValue = faker.Create<DateTime>();
        Console.WriteLine("{0}: {1}", DateValue.GetType(), DateValue);

        Console.ReadLine();
    }
}