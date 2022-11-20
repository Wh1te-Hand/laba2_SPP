using laba2_SPP;

class Program
{
    static void Main(string[] args)
    {  
        Faker faker = new Faker();

        byte byteValue = faker.Create<byte>();
        Console.WriteLine("{0}: {1}", byteValue.GetType(), byteValue);

        int intValue = faker.Create<int>();
        Console.WriteLine("{0}: {1}", intValue.GetType(),intValue);

        int charValue = faker.Create<char>();
        Console.WriteLine("{0}: {1}", charValue.GetType(), charValue);

        string stringValue = faker.Create<string>();
        Console.WriteLine("{0}: {1}", stringValue.GetType(), stringValue);

        Console.ReadLine();
    }
}