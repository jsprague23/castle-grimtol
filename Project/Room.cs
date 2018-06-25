using System.Collections.Generic;

namespace CastleGrimtol.Project
{

  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }

    public Dictionary<string, Room> Exits { get; set; }

    public Room Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return null;
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, Room>();
      Items = new List<Item>();
    }
    public void UseItem(Item item)
    {
      System.Console.WriteLine("Item Used!");
    }

    public Item Takeitem(string item)
        {
            Item found = Items.Find(i => i.Name.ToLower() == item );
            if(found != null){
                Items.Remove(found);
                return found;
            }
            return null;
        }


  }


}



