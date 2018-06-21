using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main()
    {
      Game game = new Game();
      game.Setup();
      while (game.Playing)
      {
          game.play();
      }
    }
  }
}
