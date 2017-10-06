using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.View
{
    public class OutputView
    {
        public void ShowMaze()
        {
            Console.Clear();
            Console.WriteLine("hier komt het Doolhof!!!");
        }

        public void ShowStartGame()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
            Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
            Console.WriteLine("|      · : vloer              |   naar de bestemming |");
            Console.WriteLine("|      O : krat               |                      |");
            Console.WriteLine("|      0 : krat op bestemming |                      |");
            Console.WriteLine("|      x : bestemming         |                      |");
            Console.WriteLine("|      @ : truck              |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
        }

        public void ShowEndGame(int aantal)
        {
            Console.WriteLine("Gefeliciteerd! Je hebt het doolhof opgelost in " + aantal + " zetten");
            Console.ReadKey();
        }

        public void ShowStopGame()
        {
            Console.WriteLine("Jammer dat je stopt! Tot ziens!");
            Console.ReadKey();
        }
    }
}