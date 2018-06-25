using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }

    public Player(string name)
    {
      Score = 0;
      Name = name;
      Inventory = new List<Item>();
    }
    
  }
}