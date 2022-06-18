// This is challenge work for the "C# Players Guide"
// Level 25 "Packing Inventory" Challenge
// The task is create an inventory system using inheritance

//Make a Pack object
Pack MyPack = new Pack(15, 30, 30);

while (true)
{   
    //Provide current status and max for total number of items,volume, and weight 
    MyPack.PackReport(MyPack);
    
    //Get item selection, an object is created as output
    InventoryItem UserSelection = InventoryItem.TakeItem();
    
    //Check to see if the item can be added to the bag.  Return type of bool was required by the challenge.
    //It would have been cleaner to keep all actions in the AddItem method, including the if on line 19
    bool ActionCheck = MyPack.AddItem(UserSelection);
    if (ActionCheck == true) Console.WriteLine("\nItem Added to your inventory");
    
    //Start loop over
    Console.WriteLine("Press any key to make another selection");
    Console.ReadKey();
    Console.Clear();
}

//Classes
//Base Class
public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float ItemWeight, float ItemVolume)
    {
        Weight = ItemWeight;
        Volume = ItemVolume;
    }
    //User selection Menu
    internal static InventoryItem TakeItem()
    {
        Console.WriteLine("What would you like to add to your inventory?");
        Console.WriteLine($"1) Arrow - Weight:.01 Volume:.05 ");
        Console.WriteLine($"2) Bow - Weight:1 Volume:4 ");
        Console.WriteLine($"3) Rope - Weight:1 Volume:1.5 ");
        Console.WriteLine($"4) Water - Weight:2 Volume:3 ");
        Console.WriteLine($"5) Food - Weight:1 Volume:.5 ");
        Console.WriteLine($"6) Sword - Weight:5 Volume:3 ");

        int ItemSelection = Convert.ToInt16(Console.ReadLine());

        //Using swtich in the method to build new objects based on user selection.
        //It would have been more logical to track properties in a switch rather than build objects before checking items
        //but using subclasses (vs a switch) was required by the challenge
        InventoryItem UserItem = ItemSelection switch
        {
            1 => UserItem = new Arrow(),
            2 => UserItem = new Bow(),
            3 => UserItem = new Rope(),
            4 => UserItem = new Water(),
            5 => UserItem = new Food(),
            6 => UserItem = new Sword(),
        };
        return UserItem;
    }
}

//Objects that the user can make, using base class properties. 
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
    private InventoryItem[] TotalInventory;
    public int CurrentNumberItems { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public Pack(int totalnumberitems, float maxweight, float maxvolume)
    {
        MaxItems = totalnumberitems;
        MaxWeight = maxweight;
        MaxVolume = maxvolume;
        TotalInventory = new InventoryItem[totalnumberitems];
    }

    //Void would have been better to use rather than bool, but the challenge required a bool to be used
    public bool AddItem(InventoryItem UserChoice)
    {
        if (CurrentNumberItems >= MaxItems)
        {
            Console.WriteLine("\nThis selection will exceed the number of allowed items. Please make a different selection");
            return false;
        }
        else if (CurrentWeight + UserChoice.Weight > MaxWeight)
        {
            Console.WriteLine("\nThis selection will cause your bag to be over weight. Please make a different selection.");
            return false;
        }
        else if (CurrentVolume + UserChoice.Volume > MaxVolume)
        {
            Console.WriteLine("\nThis selection will cause the volume of your bag to exceed your bags maximum capacity . Please make a different selection.");
            return false;
        }
        else
        {
            TotalInventory[CurrentNumberItems] = UserChoice;
            CurrentNumberItems++;
            CurrentWeight+= UserChoice.Weight;
            CurrentVolume+=UserChoice.Volume;
            return true;
        }

    }
    //Provides a Pack report at the start of the loop
    public void PackReport(Pack CurrentPack)
    {
        Console.WriteLine("Pack Report: ");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentNumberItems} out of a total item capacity of {MaxItems}");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentWeight} out of a total weight capacity of {MaxWeight}");
        Console.WriteLine($"Your Pack currently has {CurrentPack.CurrentVolume} out of a total volume capacity of {MaxVolume}");
        Console.WriteLine("\n");
    }
}