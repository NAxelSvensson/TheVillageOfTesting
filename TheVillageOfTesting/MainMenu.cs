using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class MainMenu
{
    
    public void Run()
    {
        Village village = new Village();
        while (true)
        {
            if (village.daysGone < 1 | village.workers.Count != 0)
            {
                Console.Clear();
                Console.WriteLine($"Day {village.daysGone + 1}. You have {village.wood} Wood. {village.metal} Metal. {village.food} Food.");
                int avalibleWorkers = 0;
                int deadWorkers = 0;
                foreach (Building building in village.buildings)
                {
                    if (building.name.Equals("House"))
                    {
                        avalibleWorkers += 2;
                    }
                }
                foreach (Worker worker in village.workers)
                {
                    avalibleWorkers--;
                    if (worker.alive == false)
                    {
                        deadWorkers++;
                    }
                }
                Console.WriteLine($"You can add {avalibleWorkers} more workers.");
                Console.WriteLine($"You have {deadWorkers} dead workers.");
                Console.WriteLine("1. Add Worker:");
                Console.WriteLine("2. Add Project:");
                Console.WriteLine("3. Bury Dead Workers:");
                Console.WriteLine("4. Day:");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1)
                {
                    Console.Clear();
                    Console.Write("What name do you want your worker to have: ");
                    string nameInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        Console.WriteLine("What occupation do you want your worker to have:");
                        Console.WriteLine(" | Farmer | Lumberjack | Miner | Builder | ");
                        string occupationInput = Console.ReadLine();
                        Console.Clear();
                        if (occupationInput.Equals("Farmer") |
                            occupationInput.Equals("Lumberjack") |
                            occupationInput.Equals("Miner") |
                            occupationInput.Equals("Builder"))
                        {
                            village.AddWorker(nameInput, occupationInput);
                        }
                        else
                        {
                            Console.WriteLine("Please write a valid occupation:");
                            Console.WriteLine("Press any key to return:");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You must have a name:");
                        Console.WriteLine("Press any key to return:");
                        Console.ReadKey();
                    }
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine($" | {village.wood} Wood | {village.metal} Metal | ");
                    Console.WriteLine("House | 5 Wood | 0 Metal | 3 Worker Days To Complete");
                    Console.WriteLine("Woodmill | 5 Wood | 1 Metal | 5 Worker Days To Complete");
                    Console.WriteLine("Quarry | 3 Wood | 5 Metal | 7 Worker Days To Complete");
                    Console.WriteLine("Farm | 5 Wood | 2 Metal | 5 Worker Days To Complete");
                    Console.WriteLine("Castle | 50 Wood | 50 Metal | 50 Worker Days To Complete");
                    Console.WriteLine("\nWon't add a project if you don't have enough materials for it:");
                    Console.Write("What project do you want to add: ");
                    string projectInput = Console.ReadLine();
                    if (projectInput.Equals("House") |
                        projectInput.Equals("Woodmill") |
                        projectInput.Equals("Quarry") |
                        projectInput.Equals("Farm") |
                        projectInput.Equals("Castle"))
                    {
                        village.AddProject(projectInput);
                    }
                }
                else if (userChoice == 3)
                {
                    village.BuryDead();
                }
                else if (userChoice == 4)
                {
                    village.Day();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter a valid number:");
                    Console.WriteLine("Press any key to return:");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("GAME OVER!");
                break;
            }
        }
    }
}
