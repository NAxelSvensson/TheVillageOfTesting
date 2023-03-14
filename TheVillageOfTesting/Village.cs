using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class Village
{
    //Attributes
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

    //Constructor
    public Village()
    {
        //Adding 10 to food
        food = 10;

        //For loop that runs 3 times
        for (int i = 0; i < 3; i++)
        {
            //Adding the house to "buildings" list
            buildings.Add(house);
        }
    }

    //Method to add a worker to the "workers" list
    public void AddWorker(string name, string occupation)
    {
        int houses = 0;

        //Getting all the buildings in "buildings" list
        foreach (Building building in buildings)
        {
            //Checking if the building is a House
            if (building.name == "House")
            {
                //Adding 2 to the variable
                houses += 2;
            }
        }
        //Checking if you have less workers than places in houses
        if (workers.Count < houses)
        {
            //Checking if the worker you want to add is a "Farmer"
            if (occupation.Equals("Farmer"))
            {
                //Making a worker that gets the delegate "AddFood"
                Worker worker = new Worker(name, "Farmer", () => AddFood());

                //Adding the worker to "workers" list
                workers.Add(worker);
            }
            //Checking if the worker you want to add is a "Lumberjack"
            else if (occupation.Equals("Lumberjack"))
            {
                //Making a worker that gets the delegate "AddWood"
                Worker worker = new Worker(name, "Lumberjack", () => AddWood());

                //Adding the worker to "workers" list
                workers.Add(worker);
            }
            //Checking if the worker you want to add is a "Miner"
            else if (occupation.Equals("Miner"))
            {
                //Making a worker that gets the delegate "AddMetal"
                Worker worker = new Worker(name, "Miner", () => AddMetal());

                //Adding the worker to "workers" list
                workers.Add(worker);
            }
            //Checking if the worker you want to add is a "Builder"
            else if (occupation.Equals("Builder"))
            {
                //Making a worker that gets the delegate "Build"
                Worker worker = new Worker(name, "Builder", () => Build());

                //Adding the worker to "workers" list
                workers.Add(worker);
            }
        }
    }

    //Method to add a project to the "projects" list
    public void AddProject(string name)
    {
        //Checking if the project you want to add is "House"
        if (name.Equals("House"))
        {
            //Checking if you have the materials to build "House"
            if (wood >= house.woodCost && metal >= house.metalCost)
            {
                //Adds the project to "projects" list
                projects.Add(house);

                //Removes the material required for the project
                wood -= house.woodCost;
                metal -= house.metalCost;
            }
        }
        //Checking if the project you want to add is "Woodmill"
        else if (name.Equals("Woodmill"))
        {
            //Checking if you have the materials to build "Woodmill"
            if (wood >= woodmill.woodCost && metal >= woodmill.metalCost)
            {
                //Adds the project to "projects" list
                projects.Add(woodmill);

                //Removes the material required for the project
                wood -= woodmill.woodCost;
                metal -= woodmill.metalCost;
            }
        }
        //Checking if the project you want to add is "Quarry"
        else if (name.Equals("Quarry"))
        {
            //Checking if you have the materials to build "Quarry"
            if (wood >= quarry.woodCost && metal >= quarry.metalCost)
            {
                //Adds the project to "projects" list
                projects.Add(quarry);

                //Removes the material required for the project
                wood -= quarry.woodCost;
                metal -= quarry.metalCost;
            }
        }
        //Checking if the project you want to add is "Farm"
        else if (name.Equals("Farm"))
        {
            //Checking if you have the materials to build "Farm"
            if (wood >= farm.woodCost && metal >= farm.metalCost)
            {
                //Adds the project to "projects" list
                projects.Add(farm);

                //Removes the material required for the project
                wood -= farm.woodCost;
                metal -= farm.metalCost;
            }
        }
        //Checking if the project you want to add is "Castle"
        else if (name.Equals("Castle"))
        {
            //Checking if you have the materials to build "Castle"
            if (wood >= castle.woodCost && metal >= castle.metalCost)
            {
                //Adds the project to "projects" list
                projects.Add(castle);

                //Removes the material required for the project
                wood -= castle.woodCost;
                metal -= castle.metalCost;
            }
        }
    }

    //Method that does a days work
    public void Day()
    {
        //Checking if you have any workers in "workers" list. If you don't have any then you´can't call day
        if (workers.Count != 0)
        {
            //Feed the workers
            FeedWorkers();

            //Getting all the workers in "workers" list
            foreach (Worker workers in workers)
            {
                //Checking if the worker is hungry
                if (workers.hungry == false)
                {
                    //If the workers is not hungry then they should to their work
                    workers.DoWork();
                }
            }
            //End of the day. daysGone is going up by 1
            daysGone++;
        }
        else
        {
            Console.WriteLine("You don't have any workers to do any work\nPlease add some workers:");
        }
    }

    //Method for the worker "Farmer" work
    public void AddFood()
    {
        foodPerDay = 0;
        int farms = 0;
        //Getting all the buildings in "buildings" list
        foreach (Building building in buildings)
        {
            //Checking how many Farms you have
            if (building.name == "Farm")
            {
                //Add 10 extra food per Farm
                farms += 10;
            }
        }
        //Getting 5 food per Farmer and 10 per Farm you have
        foodPerDay += 5 + farms;

        //Adding food
        food += foodPerDay;
    }

    //Method for the worker "Miner" work
    public void AddMetal()
    {
        metalPerDay = 0;
        int quarrys = 0;
        //Getting all the buildings in "buildings" list
        foreach (Building building in buildings)
        {
            //Checking how many Quarrys you have
            if (building.name == "Quarry")
            {
                //Add 2 extra metal per Quarry
                quarrys += 2;
            }
        }
        //Getting 1 metal per Miner and 2 per Quarry you have
        metalPerDay += 1 + quarrys;

        //Adding metal
        metal += metalPerDay;
    }

    //Method for the worker "Lumberjack" work
    public void AddWood()
    {
        woodPerDay = 0;
        int woodmill = 0;
        //Getting all the buildings in "buildings" list
        foreach (Building building in buildings)
        {
            //Checking how many Woodmills you have
            if (building.name == "Woodmill")
            {
                //Add 2 extra wood per Woodmill
                woodmill += 2;
            }
        }
        //Getting 1 wood per Lumberjack and 2 per Woodmill you have
        woodPerDay += 1 + woodmill;

        //Adding wood
        wood += woodPerDay;
    }

    //Method for the worker "Builder" work
    public void Build()
    {
        //Checking if you have any projects in the "projects" list
        if (projects.Count != 0)
        {
            //Getting the first project in the "projects" list
            Building currentProject = projects[0];

            //If the project is not done. Add another day to how long the builders have worked on it
            if (currentProject.daysWorkedOn < currentProject.daysToComplete)
            {
                currentProject.daysWorkedOn++;
            }

            //If the project is done
            if (currentProject.daysWorkedOn >= currentProject.daysToComplete)
            {
                //Change that the project is complete
                currentProject.complete = true;

                //Remove the project from "projects" list and add it to "buildings" list
                var selected = projects.Where(completedProject => completedProject.complete == true).ToList();
                selected.ForEach(completedProject => projects.Remove(completedProject));
                buildings.AddRange(selected);
            }
        }
    }

    //Method to feed the workers
    public void FeedWorkers()
    {
        //Getting all the workers in the "workers" list
        foreach (Worker worker in workers)
        {
            //Checking if they are alive. If they are not they will not get food
            if (worker.alive == true)
            {
                //Checking how long ago they have eaten
                if (worker.daysHungry < 40)
                {
                    //If you have food they will get food
                    if (food > 0)
                    {
                        //Remove 1 food
                        food -= 1;

                        //Set the worker daysHungry to 0
                        worker.daysHungry = 0;

                        //Set that the worker is not hungry
                        worker.hungry = false;
                    }
                    else
                    {
                        worker.daysHungry++;
                        worker.hungry = true;
                    }
                }
                //If they have not eaten in 40 days they will die
                else
                {
                    worker.alive = false;
                }
            }
        }
    }

    //Method to remove the dead workers from the "workers" list
    public void BuryDead()
    {
        //Removes the workers that are dead
        workers.RemoveAll(workers => workers.alive== false);
    }
}
