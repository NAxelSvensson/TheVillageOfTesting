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
            if (occupation.Equals("Farmer"))
            {
                Worker worker = new Worker(name, "Farmer", () => AddFood());
                workers.Add(worker);
            }
            else if (occupation.Equals("Lumberjack"))
            {
                Worker worker = new Worker(name, "Lumberjack", () => AddWood());
                workers.Add(worker);
            }
            else if (occupation.Equals("Miner"))
            {
                Worker worker = new Worker(name, "Miner", () => AddMetal());
                workers.Add(worker);
            }
            else if (occupation.Equals("Builder"))
            {
                Worker worker = new Worker(name, "Builder", () => Build());
                workers.Add(worker);
            }
            else
            {
                Console.WriteLine("You wrote an invalid choice:");
            }
        }
        else
        {
            Console.WriteLine("You don't have enough room to add another worker:");
        }
    }

    public void AddProject(string name)
    {
        if (name.Equals("House"))
        {
            if (wood >= house.woodCost && metal >= house.metalCost)
            {
                projects.Add(house);
                wood -= house.woodCost;
                metal -= house.metalCost;
            }
            else
            {
                Console.WriteLine("You don't have enogh materials for a house:");
            }
        }
        else if (name.Equals("Woodmill"))
        {
            if (wood >= woodmill.woodCost && metal >= woodmill.metalCost)
            {
                projects.Add(woodmill);
                wood -= woodmill.woodCost;
                metal -= woodmill.metalCost;
            }
            else
            {
                Console.WriteLine("You don't have enogh materials for a woodmill:");
            }
        }
        else if (name.Equals("Quarry"))
        {
            if (wood >= quarry.woodCost && metal >= quarry.metalCost)
            {
                projects.Add(quarry);
                wood -= quarry.woodCost;
                metal -= quarry.metalCost;
            }
            else
            {
                Console.WriteLine("You don't have enogh materials for a quarry:");
            }
        }
        else if (name.Equals("Farm"))
        {
            if (wood >= farm.woodCost && metal >= farm.metalCost)
            {
                projects.Add(farm);
                wood -= farm.woodCost;
                metal -= farm.metalCost;
            }
            else
            {
                Console.WriteLine("You don't have enogh materials for a farm:");
            }
        }
        else if (name.Equals("Castle"))
        {
            if (wood >= castle.woodCost && metal >= castle.metalCost)
            {
                projects.Add(castle);
                wood -= castle.woodCost;
                metal -= castle.metalCost;
            }
            else
            {
                Console.WriteLine("You don't have enogh materials for a castle:");
            }
        }
        else
        {
            Console.WriteLine("You wrote an invalid choice:");
        }
    }

    public void Day()
    {
        if (workers.Count != 0)
        {
            FeedWorkers();
            foreach (Worker workers in workers)
            {
                if (workers.daysHungry == 0)
                {
                    workers.DoWork();
                }
            }
            daysGone++;
        }
        else
        {
            Console.WriteLine("You don't have any workers to do any work\nPlease add some workers:");
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
        foodPerDay += 5 + farms;
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
        metalPerDay += 1 + quarrys;
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
        woodPerDay += 1 + woodmill;
        wood += woodPerDay;
    }

    public void Build()
    {
        if (projects.Count != 0)
        {
            Building currentProject = projects[0];
            if (currentProject.daysWorkedOn < currentProject.daysToComplete)
            {
                currentProject.daysWorkedOn++;
            }
            if (currentProject.daysWorkedOn >= currentProject.daysToComplete)
            {
                currentProject.complete = true;
                var selected = projects.Where(completedProject => completedProject.complete == true).ToList();
                selected.ForEach(completedProject => projects.Remove(completedProject));
                buildings.AddRange(selected);
            }
        }
    }

    public void FeedWorkers()
    {
        foreach (Worker worker in workers)
        {
            if (worker.alive == true)
            {
                if (worker.daysHungry < 40)
                {
                    if (food > 0 && worker.daysHungry >= 0)
                    {
                        food -= 1;
                        worker.daysHungry = 0;
                        worker.hungry = false;
                    }
                    else
                    {
                        worker.daysHungry++;
                        worker.hungry = true;
                        Console.WriteLine("You don't have enough food to feed the people");
                    }
                }
                else
                {
                    worker.alive = false;
                }
            }
        }
    }

    public void BuryDead()
    {
        workers.RemoveAll(workers => workers.alive== false);
    }
}
