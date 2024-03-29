﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Model;

namespace Sokoban.View
{
    public class OutputView
    {
        public void ShowMaze(Maze maze)
        {
            Console.Clear();
            Tile currentTile;
            Tile rowTile = maze.firstTile;
            while (rowTile != null)
            {
                string line = "";
                currentTile = rowTile;
                while (currentTile != null)
                {
                    if (currentTile.Content != null)
                    {
                        line += currentTile.Content.Symbol;
                    }
                    else
                    {
                        line += currentTile.Symbol;
                    }
                    currentTile = currentTile.TileEast ?? null;
                }
                rowTile = rowTile.TileSouth ?? null;
                Console.WriteLine(line);
            }
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