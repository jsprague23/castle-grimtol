using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing = true;

    public void play()
    {
      while (Playing)
      {
        Console.WriteLine("Stuck? Try typing help.");
        System.Console.WriteLine("Location: " + CurrentRoom.Name + CurrentRoom.Description);
        System.Console.WriteLine("What do you want to do?");
        string input = Console.ReadLine().ToLower().Trim();
        string[] userInput = input.Split(" ");
        switch (input)
        {
          case "use":
            System.Console.WriteLine("Which item to use?");
            var Consume = Console.ReadLine().ToLower();
            UseItem(Consume);

            // UseItem(userInput[0]);
            break;
          case "go":
            {

              System.Console.WriteLine("Which Direction?");
              var direction = Console.ReadLine();
              var splitChoice = direction.ToLower().Split(" "); //will split work???
              var nextRoom = CurrentRoom.Go(direction);
              if (nextRoom != null)
              {
                var helmet = CurrentPlayer.Inventory.Find(i => i.Name.Contains("bicycle helmet"));
                if (nextRoom.Name == "Chapter 4: The Social Security Office. " && !CurrentPlayer.Inventory.Contains(helmet))
                {
                  lose();
                  System.Console.WriteLine("You fall violently off the bikepath and die");

                }
                else if (CurrentRoom.Name == "Chapter 4: The Social Security Office. ")
                {
                  System.Console.WriteLine("Play again? Type restart to reset the game");
                }
                else
                  CurrentRoom = nextRoom;

              }
              else
              {
                Console.WriteLine("You cannot go that way.");
              }
            }
            break;
          case "take":
            {
              Console.WriteLine("Which Item to take?");
              var pickup = Console.ReadLine();
              TakeItem(pickup);
            }
            break;
          case "inventory":
            {

              for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
              {
                int displaynum = i + 1;
                System.Console.WriteLine(CurrentPlayer.Inventory == null);

                Console.WriteLine("Item: " + displaynum + " " + CurrentPlayer.Inventory[i].Name + CurrentPlayer.Inventory[i].Description);
              }
            }
            break;
          case "help":
            {
              help();
            }
            break;
          case "give-up":
            {
              giveUp();
            }
            break;
          case "restart":
            {
              Reset();
            }
            break;
          case "description":
            {
              Console.WriteLine(CurrentRoom.Description);
            }
            break;
          // case "win":
          //   {
          //     Console.WriteLine("You won! Have a nice day!");
          //     Playing = false;
          //   }
          //   break;
          case "lose":
            {
              lose();
            }
            break;

          default:
            Console.WriteLine("Invalid Option");
            break;
        }
      }
    }


    public void Setup()
    {
      Playing = true;
      string playerName = "Adventurer!";
      Console.WriteLine("Welcome to Castle Grimstol " + playerName);
      Console.WriteLine("Please select a name to continue (Be Creative!):");
      playerName = Console.ReadLine();
      CurrentPlayer = new Player(playerName);
      Console.WriteLine("Your new legal name is now " + playerName + " please contact your local social security office for more details.");
      Room livingroom = new Room("Chapter 1: The Livingroom. ", "Perplexed, you lose interest in the game and open a new browser. After some deliberation you decide to watch Despicable Me on Amazon instead. You attempt renting it with multiple credit cards to find that all of them have been declined due to your credit card information no longer being valid. You just used it earlier today without any issues, what could be wrong? You decide to call your credit card company. You are prompted to press 1 for english or 2 for spani...Suddenly you hear a loud crash in the other room. Choose your fate: Press one for English Or Investigate the mysterious noise.");
      Room LivingroomPartTwo = new Room("Chapter 1 Part 2: The Livingroom. ", "After a lengthy conversation with a customer service representative you are told there is nothing that they can do and that you need to go to the social security building in your area to get things straightened out. You have two options for transportation, the city bus or your trusty 5 speed. Choose your destiny: The city bus or the bicycle");
      Room SPLivingroomPartTwo = new Room("Capítulo 1 Parte 2: La sala de estar.", "Te pones de pie para investigar el ruido ... parece que viene del garaje. Cautelosamente enciendes la luz solo para descubrir que estás rodeado por la oscuridad. Pierdes los nervios y vuelves a entrar solo para descubrir que, en el momento en que caías tu teléfono, accidentalmente seleccionabas español en lugar de inglés. No es un problema para ti, tomaste un semestre de español en la secundaria ... hace 14 años. Después de una larga conversación con un representante de servicio al cliente, le dicen que no hay nada que puedan hacer y que necesita ir al edificio de la seguridad social en su área para arreglar las cosas. Tienes dos opciones para el transporte, el autobús urbano o tu fiel velocidad de 5. Elige tu destino: el autobús de la ciudad o la bicicleta");
      Room Bedroom = new Room("Chapter 2: The Bedroom ", "You remember that you have some change in your bedroom...but where? Hey this could be useful, a Ricky Martin mix tape. Also something shiny glistens from underneath the bed. Choose Your Destiny: Pick up the ricky martin mix tape or pick up the glistening object under the bed.");
      Room SPBedroom = new Room("Capítulo 2: El Cuarto ", "¿Recuerdas que tienes algún cambio en tu dormitorio ... pero dónde? Oye, esto podría ser útil, una cinta de mezcla de Ricky Martin. También algo brillante brilla desde debajo de la cama");
      Room garage = new Room("Chapter 3: The Garage. ", "Ah the garage, many an epic adventure has started here. Now to find your bicycle helmet...Choose your Destiny: Type open garage to continue.");
      Room SPGarage = new Room("Capítulo 3: El Garaje ", "Ah, el garaje, muchas aventuras épicas han comenzado aquí. Ahora para encontrar su casco de bicicleta ... Elige tu destino: Escriba garaje abierto para continuar");
      Room bikepath = new Room("Chapter 4: The Bike Path. ", "A quiet and efficient way to get to places along the bike path. Before you ride, you should put on your helmet, because reasons. You notice a bus stalled on the bridge, could this be the same bus? Choose Your Destiny: Type assist to go help the stalled bus or type ignore to continue your journey.");
      Room SPBikePath = new Room("Capítulo 4: La Ciclovía ", "Una forma silenciosa y eficiente de llegar a lugares a lo largo del carril bici. ¿Ha notado un autobús detenido en el puente, podría ser el mismo autobús? Elija su destino: Escriba assist para ayudar al bus detenido o escriba ignore para continuar su viaje");
      Room BusRoute = new Room("Chapter 4: The Bus Route. ", "You walk down the street to the  bus stop. As you see it approaching you grab something out of your backpack to pay your fare. What do you use? Choose your destiny: Use an item to pay for your fare.");
      Room SPBusRoute = new Room("Capítulo 4: Ruta del autobus ", "Caminas por la calle hasta la parada de autobús. Cuando lo ve acercándose, toma algo de su mochila para pagar su pasaje. ¿Que usas? Elige tu destino: Use un artículo para pagar su tarifa.");
      Room BusHelp = new Room("Chapter 4 Part 2: The broken down bus", "You run to the location of the bus. You see smoke rising from the engine and a faint cry for help inside the bus. What do you do? Type Ignore to go to continue on your journey or type save to assist the bus passengers. ");
      Room SPBusHelp = new Room("Capítulo 4 Parte 2: El autobús averiado ", " Corres hacia la ubicación del autobús. Ves humo saliendo del motor y un débil grito de ayuda dentro del autobús. ¿Qué haces? Escriba Ignorar para continuar en su viaje o escriba guardar para ayudar a los pasajeros del autobús.");
      Room SSO = new Room("Chapter 4: The Social Security Office. ", "You have finally reached the Social Security Office! As you walk through the door you even see that there isn't even a line! You walk triumphantly up to the customer service desk and reclaim your identity! Congratulations you have your name back! Your journey is over!Now what to eat for dinner?");
      Room SPSSO = new Room("Capítulo 4: Oficina del seguro social ", "¡Finalmente ha llegado a la Oficina de la Seguridad Social! Al cruzar la puerta, incluso se ve que no hay ni una sola línea! ¡Camina triunfante hasta la mesa de atención al cliente y reclama su identidad! Usted ya no " + CurrentPlayer + "! Ahora, ¿qué comer para la cena?");

      livingroom.Exits.Add("one", LivingroomPartTwo);
      livingroom.Exits.Add("investigate", SPLivingroomPartTwo);
      LivingroomPartTwo.Exits.Add("city bus", Bedroom);
      SPLivingroomPartTwo.Exits.Add("autobus de la ciudad", SPBedroom);
      LivingroomPartTwo.Exits.Add("bicycle", garage);
      SPLivingroomPartTwo.Exits.Add("bicicleta", SPGarage);
      garage.Exits.Add("open garage", bikepath);
      SPGarage.Exits.Add("garaje abierto", SPBikePath);
      bikepath.Exits.Add("assist", BusHelp);
      bikepath.Exits.Add("ignore",SSO);
      SPBikePath.Exits.Add("ignore",SPSSO);
      SPBikePath.Exits.Add("assist", SPSSO);
      BusHelp.Exits.Add("ignore", SSO);
      BusHelp.Exits.Add("save", SSO);
      SPBusHelp.Exits.Add("ignorar", SPSSO);
      SPBusHelp.Exits.Add("guardar", SPSSO);
      CurrentRoom = livingroom;


      Item bh = new Item("bicycle helmet", " It protects your melon yo!");
      Item cd = new Item("cd", "when you're feeling upside inside out.");
      Item spbh = new Item("casco de bicicleta", " ¡Protege tu cabeza!");
      garage.Items.Add(bh);
      SPGarage.Items.Add(spbh);
      Bedroom.Items.Add(cd);

    }

    public void help()
    {

      Console.WriteLine("Try typing go to navigate between rooms, take to pick up an item, use to use an item, give-up to quit game, inventory to see items you are holding, type description to show room's description, or restart to reset the game.");
      Console.ReadLine();
    }

    public void lose()
    {
      System.Console.WriteLine("You faltered along your journey.");
      Playing = false;
    }

    public void giveUp()
    {

      Console.WriteLine("The journey proved too difficult, you decide to give up");
      Playing = false;
    }

    public void UseItem(string itemName)
    {

      Item found = CurrentPlayer.Inventory.Find(i => i.Name.Contains(itemName));
      if (found != null)
      {
        if (CurrentRoom.Name == "Chapter 4: The Bike Path. " || CurrentRoom.Name == "Capítulo 4: La Ciclovía " && found.Name == "bicycle helmet" || found.Name =="casco de bicicleta")
        {
          System.Console.WriteLine($"You used the {itemName}.");
          System.Console.WriteLine("You use the {itemName} and traverse the bike path");
        }
        else
        {
          System.Console.WriteLine("You cannot use that item here.");
        }
      }
      // if(found!=null)
      // {
      //   if(CurrentRoom.Name == )
      // }
      if (found!=null)
      {
        System.Console.WriteLine($"You used the {itemName}.");
      }
      else
        {
          System.Console.WriteLine("You cannot use that item here.");
        }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(x => x.Name == itemName);

      if (item != null)
      {
        Console.WriteLine($"You pick up the {itemName}.");
        CurrentPlayer.Inventory.Add(item);
        CurrentRoom.Items.Remove(item);
      }
      else
      {
        System.Console.WriteLine("Not a valid choice");
      }
    }
    public void setCurrentRoom(Room room)
    {
      CurrentRoom = room;
    }

    public void Reset()
    {
      Setup();
    }


  }
}
// {
// LivingroomPartTwo.exits.Add("east", "room3":"west", "room1");
// SPLivingroomPartTwo.exits.Add("east", "room4":"west", "room2");
// Bedroom.exits.Add("east", "room5":"west", "room3");
// SPBedroom.exits.Add("east", "room6":"west", "room4");
// Garage.exits.Add(west","room5");

// SPGarage.exits.Add(west","room5");

// BikePath.exits.Add(west","room5");

// SPBikePath.exits.Add(west","room5");

// BusRoute.exits.Add(west","room5");


// Item BP = new Item("Bus Pass", "It belongs to your room mate, but they never check the picture anyways");
// Item LC = new Item("Loose Change", "3 quarters, 7 dimes,  and 4 nickels");
// Item MO = new Item("Slim Jim", "What you were before you ate this.");
// Item W = new Item("Window", "Safelite repair, safelite replace");
// // Item K =new Item ("Key", "Used for unlocking doors, not a geographical feature");
// // Item N =new Item ("Note","A hurried message was scrawled onto parchment 'Shia Lebouf is coming'");
// Item V = new Item("Vial", "Shaped like the Aunt Jamima Syrup Bottle...");
// }

// switch (input.ToLower())
// {
//   case "south":
//     setCurrentRoom(CurrentRoom.Exits["south"]);
//     break;
//    case "north":         
//     setCurrentRoom(CurrentRoom.Exits["north"]);
//     break;
//     default:
//     System.Console.WriteLine($"({input})is not a valid option");
//     break;        
// }