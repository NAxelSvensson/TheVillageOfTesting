using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVillageOfTesting;

public class Building
{
    public string name = "";
    public int woodCost;
    public int metalCost;
    public int daysWorkedOn;
    public int daysToComplete;
    public bool complete;
    public Building(string name, int woodCost, int metalCost, int daysToComplete)
    {
        this.name = name;
        this.woodCost = woodCost;
        this.metalCost = metalCost;
        daysWorkedOn = 0;
        this.daysToComplete = daysToComplete;
        complete = false;
    }
}
