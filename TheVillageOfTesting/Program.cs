namespace TheVillageOfTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating a object from the class MainMenu
            MainMenu mainMenu = new MainMenu();

            //Running the "Run" method from MainMenu class that starts the main menu for the program
            mainMenu.Run();
        }
    }
}