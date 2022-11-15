using laba2_SPP;

class Program
{
    static void Main(string[] args)
    {  
        Faker faker = new Faker();

        byte byteValue = faker.Create<byte>();
        Console.WriteLine("{0}: {1}", byteValue.GetType(), byteValue);

        Console.ReadLine();
    }
}