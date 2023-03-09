using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class Village
{
    public int food;
    public int wood;
    public int metal;
    public List<Worker> workers = new();
    public List<Building> buildings = new();
    public List<Building> projects = new();
    public int metalPerDay;
    public int woodPerDay;
    public int foodPerDay;
    public int daysGone;
    Building house = new("House", 5, 0, 3);
    Building woodmill = new("Woodmill", 5, 1, 5);
    Building quarry = new("Quarry", 3, 5, 7);
    Building farm = new("Farm", 5, 2, 5);
    Building castle = new("Castle", 50, 50, 50);
    public Village()
    {
        food = 10;

        for (int i = 0; i < 3; i++)
        {
            buildings.Add(house);
        }
    }

    public void AddWorker(string name, string occupation)
    {
        int houses = 0;
        foreach (Building building in buildings)
        {
            if (building.name == "House")
            {
                houses += 2;
            }
        }
        if (workers.Count < houses)
        {
            while (true)
            {
                if (occupation.Equals("Farmer"))
                {
                    Worker worker = new Worker(name, occupation, () => AddFood());
                    workers.Add(worker);
                }
                else if (occupation.Equals("Lumberjack"))
                {
                    Worker worker = new Worker(name, occupation, () => AddWood());
                    workers.Add(worker);
                }
                else if (occupation.Equals("Miner"))
                {
                    Worker worker = new Worker(name, occupation, () => AddMetal());
                    workers.Add(worker);
                }
                else if (occupation.Equals("Builder"))
                {
                    Worker worker = new Worker(name, occupation, () => Build());
                    workers.Add(worker);
                }
                else
                {
                    Console.WriteLine("Please Enter a valid number:");
                }
            }
        }
        else
        {
            Console.WriteLine("You don't have enough houses to add more workers.");
        }
    }

    public void AddProject(string name)
    {
        while (true)
        {
            Console.WriteLine("What building do you want to start building:");
            Console.WriteLine($"You have {wood} Wood and {metal} Metal:");
            Console.WriteLine("1. House: 5 Wood and 0 Metal: 3 Days to build:");
            Console.WriteLine("2. Woodmill: 5 Wood and 1 Metal: 5 Days to build:");
            Console.WriteLine("3. Quarry: 3 Wood and 5 Metal: 7 Days to build:");
            Console.WriteLine("4. Farm: 5 Wood and 2 Metal: 5 Days to build:");
            Console.WriteLine("5. Castle: 50 Wood and 50 Metal: 50 Days to build:");
            Console.WriteLine("6. Go back:");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            if (userChoice == 1)
            {
                projects.Add(house);
                break;
            }
            else if (userChoice == 2)
            {
                projects.Add(woodmill);
                break;
            }
            else if (userChoice == 3)
            {
                projects.Add(quarry);
                break;
            }
            else if (userChoice == 4)
            {
                projects.Add(farm);
                break;
            }
            else if (userChoice == 5)
            {
                projects.Add(castle);
                break;
            }
            else if (userChoice == 6)
            {
                break;
            }
            else
            {
                Console.WriteLine("Your choice is not valid. Please Enter a valid number:");
                Console.WriteLine("Press any key to return:");
                Console.ReadKey();
            }
        }
    }

    public void Day()
    {
        foreach (Worker workers in workers)
        {
            if(workers.daysHungry == 0)
            {
                workers.DoWork();
            }
            FeedWorkers();
            daysGone++;
            BuryDead();
        }
    }

    public void AddFood()
    {
        foodPerDay = 0;
        int farms = 0;
        foreach (Building building in buildings)
        {
            if (building.name == "Farm")
            {
                farms += 10;
            }
        }
        foreach (Worker worker in workers)
        {
            if (worker.occupation == "foo")
            {
                foodPerDay += 5 + farms;
            }
        }
        food += foodPerDay;
    }

    public void AddMetal()
    {
        metalPerDay = 0;
        int quarrys = 0;
        foreach (Building building in buildings)
        {
            if (building.name == "Quarry")
            {
                quarrys += 2;
            }
        }
        foreach (Worker worker in workers)
        {
            if (worker.occupation == "foo")
            {
                metalPerDay += 1 + quarrys;
            }
        }
        metal += metalPerDay;
    }

    public void AddWood()
    {
        woodPerDay = 0;
        int woodmill = 0;
        foreach (Building building in buildings)
        {
            if (building.name == "Woodmill")
            {
                woodmill += 2;
            }
        }
        foreach (Worker worker in workers)
        {
            if (worker.occupation == "foo")
            {
                woodPerDay += 1 + woodmill;
            }
        }
        wood += woodPerDay;
    }

    public void Build()
    {
        Building currentProject = projects[0];
        if (currentProject.daysWorkedOn < currentProject.daysToComplete)
        {
            currentProject.daysWorkedOn++;
        }
        else if (currentProject.daysWorkedOn >= currentProject.daysToComplete)
        {
            currentProject.complete = true;
            //var selected = from completedProject in projects where completedProject.complete == true select completedProject;
            var selected = projects.Where(completedProject => completedProject.complete == true).ToList();
            selected.ForEach(completedProject => projects.Remove(completedProject));
            buildings.AddRange(selected);
        }
    }

    public void FeedWorkers()
    {
        Worker.Feed();
    }

    public void BuryDead()
    {
        foreach (Worker worker in workers)
        {
            if (worker.alive == false)
            {
                workers.Remove(worker);
            }
        }
    }
}
