// This is challenge work for the "C# Players Guide"
// Level 25 "Packing Inventory" Challenge
// The task is create an inventory system using inheritance



//Test

Pack MyPack = new Pack(20, 20, 30);
MyPack.PackReport(MyPack);
Console.ReadLine();

//Classes
public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float ItemWeight, float ItemVolume)
    {
        Weight = ItemWeight;
        Volume = ItemVolume;
    }
}
public class Arrow : InventoryItem    
{
    public Arrow() : base(0.1f, 0.05f) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
}
public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
}
public class Water : InventoryItem
{
    public Water() : base(2f, 3f){ }
}
public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) {  }
}
public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
}

public class Pack
{
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    private int[] TotalInventory;
    public int CurrentNumberItems { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public Pack(int totalnumberitems, float maxweight, float maxvolume)
    {
        MaxItems = totalnumberitems;
        MaxWeight = maxweight;
        MaxVolume = maxvolume;
        TotalInventory = new int[totalnumberitems];
    }

    public void PackReport(Pack CurrentPack)
    {
        Console.WriteLine("Pack Report: ");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentNumberItems/MaxItems} out of a total item capacity of {MaxItems}");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentWeight / MaxWeight} out of a total weight capacity of {MaxWeight}");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentVolume / MaxVolume} out of a total volume capacity of {MaxVolume}");
    }
}