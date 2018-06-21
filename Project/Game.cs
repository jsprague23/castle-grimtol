using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing { get; set; }
    public void play()
    {
      System.Console.WriteLine("Location: " + CurrentRoom.Name + CurrentRoom.Description);
      System.Console.WriteLine("What do you want to do?");
      Console.ReadLine();
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
      //   //method to take user input
      Room livingroom = new Room("Chapter 1 The Livingroom ", "Perplexed, you lose interest in the game and open a new browser. After some deliberation you decide to watch Despicable Me on Amazon instead. You attempt renting it with multiple credit cards to find that all of them have been declined due to your credit card information no longer being valid. You just used it earlier today without any issues, what could be wrong? You decide to call your credit card company. You are prompted to press 1 for english or 2 for spani...Suddenly you hear a loud crash in the other room. Choose your fate: Press one for English Or Investigate the mysterious noise. *HOTFIX* Type South to proceed to the Garage");
      // Room LivingroomPartTwo = new Room("Chapter 2 The Livingroom ", "After a lengthy conversation with a customer service representative you are told there is nothing that they can do and that you need to go to the social security building in your area to get things straightened out. You have two options for transportation, the city bus or your trusty 5 speed. Choose your destiny: The city bus or the bicycle");
      // Room SPLivingroomPartTwo = new Room("Sala ", "Te pones de pie para investigar el ruido ... parece que viene del garaje. Cautelosamente enciendes la luz solo para descubrir que estás rodeado por la oscuridad. Pierdes los nervios y vuelves a entrar solo para descubrir que, en el momento en que caías tu teléfono, accidentalmente seleccionabas español en lugar de inglés. No es un problema para ti, tomaste un semestre de español en la secundaria ... hace 14 años. Después de una larga conversación con un representante de servicio al cliente, le dicen que no hay nada que puedan hacer y que necesita ir al edificio de la seguridad social en su área para arreglar las cosas. Tienes dos opciones para el transporte, el autobús urbano o tu fiel velocidad de 5. Elige tu destino: el autobús de la ciudad o la bicicleta");
      // Room Bedroom = new Room("Chapter 3: The Bedroom ", "You remember that you have some change in your bedroom...but where? Hey this could be useful, a Ricky Martin mix tape. Also something shiny glistens from underneath the bed. Choose Your Destiny: Pick up the ricky martin mix tape or pick up the glistening object under the bed *HOTFIX* Type East to go to the ");
      // Room SPBedroom = new Room("Cuarto ", "¿Recuerdas que tienes algún cambio en tu dormitorio ... pero dónde? Oye, esto podría ser útil, una cinta de mezcla de Ricky Martin. También algo brillante brilla desde debajo de la cama");
      Room garage = new Room("Chapter 2: The Garage ", "Ah the garage, many an epic adventure has started here. Now to find your helmet...Choose your Destiny: Pick up helmet *Hotfix* Type East to go to the bikepath or north to go back to the livingroom");
      // Room SPGarage = new Room("Garaje ", "Ah, el garaje, muchas aventuras épicas han comenzado aquí. Ahora para encontrar tu casco ... Elige tu destino: recoger el casco");
      Room bikepath = new Room("Chapter 3: The Bike Path ", "A quiet and efficient way to get to places along the bike path. You notice a bus stalled on the bridge, could this be the same bus? Choose Your Destiny: Go help the stalled bus or continue your journey *HOTFIX* Type west to go back to the garage or type North to go to the social security office.");
      // Room SPBikePath = new Room("Ciclovía ", "Una forma silenciosa y eficiente de llegar a lugares a lo largo del carril bici. ¿Ha notado un autobús detenido en el puente, podría ser el mismo autobús? Elija su destino: vaya a ayudar al autobús detenido o continúe su viaje");
      // Room BusRoute = new Room("Chapter 4: The Bus Route ", "You walk down the street to the  bus stop. As you see it approaching you grab something out of your backpack to pay your fare. What do you use? Choose your destiny: *hint* type backpack to see items you have picked up");
      // Room SPBusRoute = new Room("Ruta del autobus ", "Caminas por la calle hasta la parada de autobús. Cuando lo ve acercándose, toma algo de su mochila para pagar su pasaje. ¿Que usas? Elige tu destino: * pista * escribe la mochila para ver los artículos que has recogido");
      Room SSO = new Room("Chapter 4: The Social Security Office ", "You have finally reached the Social Security Office! As you walk through the door you even see that there isn't even a line! You walk triumphantly up to the customer service desk and reclaim your identity! Congratulations you are no longer " + CurrentPlayer + "! Now what to eat for dinner?");
      // Room SPSSO = new Room("Oficina del seguro social ", "¡Finalmente ha llegado a la Oficina de la Seguridad Social! Al cruzar la puerta, incluso se ve que no hay ni una sola línea! ¡Camina triunfante hasta la mesa de atención al cliente y reclama su identidad! Usted ya no " + CurrentPlayer + "! Ahora, ¿qué comer para la cena?");

    {
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
      // Item BH = new Item("Bicycle Helmet", "Protect your melon yo");
      // Item LC = new Item("Loose Change", "3 quarters, 7 dimes,  and 4 nickels");
      // Item MO = new Item("Slim Jim", "What you were before you ate this.");
      // Item W = new Item("Window", "Safelite repair, safelite replace");
      // // Item K =new Item ("Key", "Used for unlocking doors, not a geographical feature");
      // // Item N =new Item ("Note","A hurried message was scrawled onto parchment 'Shia Lebouf is coming'");
      // Item V = new Item("Vial", "Shaped like the Aunt Jamima Syrup Bottle...");
    }
      livingroom.Exits.Add("south", garage);
      garage.Exits.Add("east", bikepath);
      bikepath.Exits.Add("north", SSO);
      var input = Console.ReadLine().ToLower();

      switch (input)
      {
        case "south":
          CurrentRoom=garage;
          break;
        case "east":
          CurrentRoom=bikepath;
          break;
        case "north":
          CurrentRoom=SSO;
          break;
          default:
          System.Console.WriteLine($"({input})is not a valid option");
          break;        
      }
      CurrentRoom = livingroom;

        // if(CurrentRoom!==input)
        // {
        //   System.Console.WriteLine(CurrentRoom.Description);
        // }
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}