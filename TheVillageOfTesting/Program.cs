namespace TheVillageOfTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village();
            foreach(Building buildings in village.buildings) 
            {
                Console.WriteLine(buildings.name);
            }
        }
    }
}