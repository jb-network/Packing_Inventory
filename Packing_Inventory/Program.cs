// This is challenge work for the "C# Players Guide"
// Level 25 "Packing Inventory" Challenge
// The task is create an inventory system using inheritance



//Test
InventoryItem TestItem = new InventoryItem(1.1f, 3.3f);
Console.WriteLine("Super Class Test:");
Console.WriteLine($"Weight: {TestItem.Weight}");
Console.WriteLine($"Volume: {TestItem.Volume}");

Arrow Arrow = new Arrow();
Console.WriteLine("Sub Class Test:");
Console.WriteLine($"Weight: {Arrow.Weight}");
Console.WriteLine($"Volume: {Arrow.Volume}");
Console.WriteLine($"Test String: {Arrow.test}");
Console.ReadKey();

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
    public string test;
    public Arrow() : base(0.1f, 0.05f) 
    {
        test = "This is a test"; 
    }
}
