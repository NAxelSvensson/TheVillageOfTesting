using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class MainMenu
{
    //Method for the main menu
    public void Run()
    {
        Village village = new Village();
        
        //Using a while loop to keep the program running
        while (true)
        {
            //Checking if more than 1 day has gone or if the user don't have 0 workers. Used so that if you have 0 workers after 1 day it's game over
            if (village.daysGone <= 1 | village.workers.Count != 0)
            {
                //Clearing the console to make it cleaner
                Console.Clear();

                //Writing which day it is and how much the user have of the resources
                Console.WriteLine($"Day {village.daysGone + 1}. You have {village.wood} Wood. {village.metal} Metal. {village.food} Food.");
                int avalibleWorkers = 0;
                int deadWorkers = 0;

                //Getting all the buildings in "buildings" list
                foreach (Building building in village.buildings)
                {
                    //Checking if the building is a "House"
                    if (building.name.Equals("House"))
                    {
                        //Add 2 to avalibleWorkers
                        avalibleWorkers += 2;
                    }
                    //Checking if the building is a "Castle"
                    else if (building.name.Equals("Castle"))
                    {
                        //Clearing the console to make it cleaner
                        Console.Clear();

                        //Writing that the user have won and closes the program
                        Console.WriteLine("YOU HAVE WON!");
                        break;
                    }
                }
                //Getting all the workers in "workers" list
                foreach (Worker worker in village.workers)
                {
                    //Take away 1 from avalibleWorkers
                    avalibleWorkers--;

                    //Checking if the worker is alive
                    if (worker.alive == false)
                    {
                        //Adds 1 to deadWorkers
                        deadWorkers++;
                    }
                }
                //Writing how many workers the user can add
                Console.WriteLine($"You can add {avalibleWorkers} more workers.");

                //Writing how many dead workers the user have
                Console.WriteLine($"You have {deadWorkers} dead workers.");

                //Writing the avalible options
                Console.WriteLine("1. Add Worker:");
                Console.WriteLine("2. Add Project:");
                Console.WriteLine("3. Bury Dead Workers:");
                Console.WriteLine("4. Day:");
                Console.Write("What do you want to do: ");

                //Getting the user choice
                int userChoice = Convert.ToInt32(Console.ReadLine());

                //Checking if the user choose 1 or "Add Worker"
                if (userChoice == 1)
                {
                    //Clearing the console to make it cleaner
                    Console.Clear();

                    //Asking what name the worker should have
                    Console.Write("What name do you want your worker to have: ");

                    //Getting the user choice
                    string nameInput = Console.ReadLine();

                    //Checking if the user has actually added a name
                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        //Asking what occupation the worker should have
                        Console.WriteLine("What occupation do you want your worker to have:");

                        //Writing the different occupations there are
                        Console.WriteLine(" | Farmer | Lumberjack | Miner | Builder | ");

                        //Getting the user choice
                        string occupationInput = Console.ReadLine();

                        //Clearing the console to make it cleaner
                        Console.Clear();

                        //Checking if the user has writen any of the avalible occupations
                        if (occupationInput.Equals("Farmer") |
                            occupationInput.Equals("Lumberjack") |
                            occupationInput.Equals("Miner") |
                            occupationInput.Equals("Builder"))
                        {
                            //Adding the worker with the name and occupation
                            village.AddWorker(nameInput, occupationInput);
                        }
                        //If the user did not write any of the avalible occupations
                        else
                        {
                            Console.WriteLine("Please write a valid occupation:");
                            Console.WriteLine("Press any key to return:");
                            Console.ReadKey();
                        }
                    }
                    //If the user did not write anything
                    else
                    {
                        Console.WriteLine("You must have a name:");
                        Console.WriteLine("Press any key to return:");
                        Console.ReadKey();
                    }
                }
                //Checking if the user choose 2 or "Add Project"
                else if (userChoice == 2)
                {
                    //Clearing the console to make it cleaner
                    Console.Clear();

                    //Writing how much material the user have
                    Console.WriteLine($" | {village.wood} Wood | {village.metal} Metal | ");

                    //Writing the different buildings you can add to project
                    Console.WriteLine("House | 5 Wood | 0 Metal | 3 Worker Days To Complete");
                    Console.WriteLine("Woodmill | 5 Wood | 1 Metal | 5 Worker Days To Complete");
                    Console.WriteLine("Quarry | 3 Wood | 5 Metal | 7 Worker Days To Complete");
                    Console.WriteLine("Farm | 5 Wood | 2 Metal | 5 Worker Days To Complete");
                    Console.WriteLine("Castle | 50 Wood | 50 Metal | 50 Worker Days To Complete");
                    Console.WriteLine("\nWon't add a project if you don't have enough materials for it:");

                    //Asking what the user wants to start
                    Console.Write("What project do you want to add: ");

                    //Getting the user choice
                    string projectInput = Console.ReadLine();

                    //Checking if the user has writen any of the avalible projects
                    if (projectInput.Equals("House") |
                        projectInput.Equals("Woodmill") |
                        projectInput.Equals("Quarry") |
                        projectInput.Equals("Farm") |
                        projectInput.Equals("Castle"))
                    {
                        //Adding the building to the "projects" list
                        village.AddProject(projectInput);
                    }
                    //If the user did not write any of the avalible projects
                    else
                    {
                        Console.WriteLine("Please write a valid project:");
                        Console.WriteLine("Press any key to return:");
                        Console.ReadKey();
                    }
                }
                //Checking if the user choose 3 or "Bury Dead Workers"
                else if (userChoice == 3)
                {
                    //Call the method BuryDead
                    village.BuryDead();
                }
                //Checking if the user choose 4 or "Day"
                else if (userChoice == 4)
                {
                    //Call the method Day
                    village.Day();
                }
                //If the user did not choose a valid number
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter a valid number:");
                    Console.WriteLine("Press any key to return:");
                    Console.ReadKey();
                }
            }
            //If the user lost the game
            else
            {
                Console.WriteLine("GAME OVER!");
                break;
            }
        }
    }
}
