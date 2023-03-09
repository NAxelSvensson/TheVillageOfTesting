using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class Worker
{
    public delegate void WorkerDelegate();
    public WorkerDelegate workerDelegate;

    public string name = "";
    public string occupation = "";
    public bool hungry;
    public int daysHungry;
    public bool alive;
    public Worker(string name, string occupation, WorkerDelegate workerDelegate)
    {
        this.name = name;
        this.occupation = occupation;
        this.workerDelegate = workerDelegate;
        hungry = false;
        daysHungry = 0;
        alive = true;
    }

    public void DoWork()
    {
        workerDelegate.Invoke();
    }

    public static void Feed()
    {
        Village village = new Village();
        foreach (Worker worker in village.workers)
        {
            if (worker.daysHungry < 40)
            {
                if (village.food > 0 && worker.daysHungry >= 0)
                {
                    village.food -= 1;
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
