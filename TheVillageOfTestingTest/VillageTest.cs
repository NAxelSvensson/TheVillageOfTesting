using TheVillageOfTesting;

namespace TheVillageOfTestingTest;

public class VillageTest
{
    [Fact]
    public void Adding1Worker_ShouldHave1Worker()
    {
        //given
        Village village= new Village();
        int expectedWorkers = 1;

        //when
        village.AddWorker("Jim", "Farmer");
        int workerCount = village.workers.Count;

        //then
        Assert.Equal(expectedWorkers, workerCount);
    }
    [Fact]
    public void Adding2Worker_ShouldHave2Worker()
    {
        //given
        Village village = new Village();
        int expectedWorkers = 2;

        //when
        village.AddWorker("Jim", "Miner");
        village.AddWorker("Bob", "Lumberjack");
        int workerCount = village.workers.Count;

        //then
        Assert.Equal(expectedWorkers, workerCount);
    }
    [Fact]
    public void Adding3Worker_ShouldHave3Worker()
    {
        //given
        Village village = new Village();
        int expectedWorkers = 3;

        //when
        village.AddWorker("Jim", "Builder");
        village.AddWorker("Bob", "Miner");
        village.AddWorker("Jack", "Lumberjack");
        int workerCount = village.workers.Count;

        //then
        Assert.Equal(expectedWorkers, workerCount);
    }
    [Fact]
    public void AddingWorkerWhenNoSpace_NoWorkerShouldBeAdded()
    {
        //given
        Village village = new Village();
        village.buildings.Clear();
        int expectedWorkers = 0;

        //when
        village.AddWorker("Worker1", "Miner");
        village.AddWorker("Worker2", "Lumberjack");
        village.AddWorker("Worker3", "Builder");
        village.AddWorker("Worker4", "Farmer");
        int workerCount = village.workers.Count();

        //then
        Assert.Equal(expectedWorkers, workerCount);
    }
    [Fact]
    public void TestingSoWorkerDoesTheRightWork()
    {
        //given
        Village village = new Village();
        village.AddWorker("Jim", "Miner");
        village.metal = 0;
        int expectedMetal = 1;

        //when
        village.Day();
        int actualMetal = village.metal;

        //then
        Assert.Equal(expectedMetal, actualMetal);
        
    }
    /*
    [Fact]
    public void TestingDayWithNoWorkers()
    {
        //given
        Village village = new Village();

        //when
        village.Day();

        //then
    
    }*/
    [Theory]
    [InlineData("House", 10, 12, 5, 12)]
    [InlineData("House", 6, 1, 1, 1)]
    [InlineData("Woodmill", 8, 5, 3, 4)]
    [InlineData("Woodmill", 15, 13, 10, 12)]
    [InlineData("Quarry", 9, 11, 6, 6)]
    [InlineData("Quarry", 7, 7, 4, 2)]
    [InlineData("Farm", 5, 2, 0, 0)]
    [InlineData("Farm", 7, 6, 2, 4)]
    [InlineData("Castle", 57, 56, 7, 6)]
    [InlineData("Castle", 68, 60, 18, 10)]
    public void AddingAProjectWithEnoughMaterial(string name, int wood, int metal, int expectedLeftoverWood, int expectedLeftoverMetal)
    {
        //given
        Village village = new Village();
        village.wood = wood;
        village.metal = metal;
        int expectedWoodLeft = expectedLeftoverWood;
        int expectedMetalLeft = expectedLeftoverMetal;
        int expectedProjects = 1;

        //when
        village.AddProject(name);
        int actualWoodLeft = village.wood;
        int actualMetalLeft = village.metal;
        int actualProjects = village.projects.Count();

        //then
        Assert.Equal(expectedWoodLeft, actualWoodLeft);
        Assert.Equal(expectedMetalLeft, actualMetalLeft);
        Assert.Equal(expectedProjects, actualProjects);
    }
    [Theory]
    [InlineData("House", 4, 2)]
    [InlineData("Woodmill", 3, 3)]
    [InlineData("Quarry", 4, 4)]
    [InlineData("Farm", 6, 1)]
    [InlineData("Castle", 49, 49)]
    public void AddingAProjectWithNotEnoughMaterial(string name, int wood, int metal)
    {
        //given
        Village village = new Village();
        village.wood = wood;
        village.metal = metal;
        int expectedProjects = 0;

        //when
        village.AddProject(name);
        int actualProjects = village.projects.Count();

        //then
        Assert.Equal(expectedProjects, actualProjects);
    }
    [Fact]
    public void LumberjackGatherMoreWoodWithWoodmill()
    {
        //given
        Village village = new Village();
        village.food = 10000;
        village.wood = 10000;
        village.metal = 10000;
        village.AddWorker("Jim", "Lumberjack");
        int expectedWoodPerDayBeforeWoodmill = 1;
        int expectedWoodPerDayAfterWoodmill = 3;

        //when
        village.Day();
        int actualWoodPerDayBeforeWoodmill = village.woodPerDay;
        Building testBuilding = new Building("Woodmill", 1, 1, 1);
        village.buildings.Add(testBuilding);
        village.Day();
        int actualWoodPerDayAfterWoodmill = village.woodPerDay;

        //then
        Assert.Equal(expectedWoodPerDayBeforeWoodmill, actualWoodPerDayBeforeWoodmill);
        Assert.Equal(expectedWoodPerDayAfterWoodmill, actualWoodPerDayAfterWoodmill);
    }
    [Fact]
    public void MinerGatherMoreMetalWithQuarry()
    {
        //given
        Village village = new Village();
        village.food = 10000;
        village.wood = 10000;
        village.metal = 10000;
        village.AddWorker("Jim", "Miner");
        int expectedMetalPerDayBeforeQuarry = 1;
        int expectedMetalPerDayAfterQuarry = 3;

        //when
        village.Day();
        int actualMetalPerDayBeforeQuarry = village.metalPerDay;
        Building testBuilding = new Building("Quarry", 1, 1, 1);
        village.buildings.Add(testBuilding);
        village.Day();
        int actualMetalPerDayAfterQuarry = village.metalPerDay;

        //then
        Assert.Equal(expectedMetalPerDayBeforeQuarry, actualMetalPerDayBeforeQuarry);
        Assert.Equal(expectedMetalPerDayAfterQuarry, actualMetalPerDayAfterQuarry);
    }
    [Fact]
    public void FarmerGatherMoreFoodWithFarm()
    {
        //given
        Village village = new Village();
        village.food = 10000;
        village.wood = 10000;
        village.metal = 10000;
        village.AddWorker("Jim", "Farmer");
        int expectedFoodPerDayBeforeFarm = 5;
        int expectedFoodPerDayAfterFarm = 15;

        //when
        village.Day();
        int actualFoodPerDayBeforeFarm = village.foodPerDay;
        Building testBuilding = new Building("Farm", 1, 1, 1);
        village.buildings.Add(testBuilding);
        village.Day();
        int actualFoodPerDayAfterFarm = village.foodPerDay;

        //then
        Assert.Equal(expectedFoodPerDayBeforeFarm, actualFoodPerDayBeforeFarm);
        Assert.Equal(expectedFoodPerDayAfterFarm, actualFoodPerDayAfterFarm);
    }
    [Fact]
    public void TestThatBuildingAHouseTakesHowLongItShould()
    {
        //given
        Village village = new Village();
        village.wood = 5;
        village.AddWorker("Jim", "Builder");
        village.AddProject("House");
        int expectedDays = 3;

        //when
        while(village.buildings.Count == 3) 
        {
            village.Day();
        }
        int actualDays = village.daysGone;

        //then
        Assert.Equal(expectedDays, actualDays);
    }
    [Fact]
    public void WorkerThatGetsNoFoodShouldNotWork()
    {
        //given
        Village village = new Village();
        village.food = 0;
        village.wood = 0;
        village.AddWorker("Jim", "Lumberjack");
        int expectedWood = 0;

        //when
        village.Day();
        int actualWood = village.wood;

        //then
        Assert.Equal(expectedWood, actualWood);
    }
    [Fact]
    public void WorkerHasNotGottenFoodIn40DaysShouldDie()
    {
        //given
        Village village = new Village();
        Worker worker = new Worker("Jim", "Miner", () => village.AddMetal());
        village.workers.Add(worker);
        village.food = 0;
        worker.daysHungry = 40;

        //when
        village.FeedWorkers();
        bool actualStatus = worker.alive;

        //then
        Assert.False(actualStatus);
    }
    [Fact]
    public void WorkerWhoIsDeadShouldNotEat()
    {
        //given
        Village village = new Village();
        Worker worker = new Worker("Jim", "Miner", () => village.AddMetal());
        village.workers.Add(worker);
        village.food = 10;
        worker.alive= false;
        int expectedFood = 10;

        //when
        village.FeedWorkers();
        int actualFood = village.food;

        //then
        Assert.Equal(expectedFood, actualFood);
    }
    [Fact]
    public void BuryDeadTakesAwayDeadWorkers()
    {
        //given
        Village village = new Village();
        Worker worker = new Worker("Jim", "Miner", () => village.AddMetal());
        village.workers.Add(worker);
        worker.alive = false;
        int expectedWorekersLeft = 0;

        //when
        village.BuryDead();
        int actualWorkersLeft = village.workers.Count();

        //then
        Assert.Equal(expectedWorekersLeft, actualWorkersLeft);
    }
}