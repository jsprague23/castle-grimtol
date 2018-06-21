using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    
    public Dictionary<string, Room> Exits { get; set; }
    
    
    // Exits Livingroom = new Exits("south", Garage)
    // Exits Garage = new Exits("east", BikePath)
    // Exits BikePath = new Exits("north", SSO)
    
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, Room>();
    }
    public void UseItem(Item item)
    {
      System.Console.WriteLine("Item Used!");
    }

   
    }


}



