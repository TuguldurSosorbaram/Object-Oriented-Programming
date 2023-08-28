namespace BagType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bag:");
            Menu test = new();
            test.Run();
            Bag bag = new Bag();
            bag.putin(1);
            bag.takeout(1);

        }
    }
}