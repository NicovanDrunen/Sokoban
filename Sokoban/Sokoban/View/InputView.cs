using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.View
{
    public class InputView
    {
        public int AskMazeNumber()
        {
            int MazeNumber = 0;
            Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");
            ConsoleKeyInfo Input = Console.ReadKey();
            Console.WriteLine("");
            if (char.IsDigit(Input.KeyChar) && Input.KeyChar <= '4' && Input.KeyChar >= '1')
            {
                MazeNumber = (int)Char.GetNumericValue(Input.KeyChar);
            }
            else if(Input.KeyChar == 's')
            {
                MazeNumber = -1;
            }
            else
            {
                Console.WriteLine("Dit is geen legitieme input");
                MazeNumber = AskMazeNumber();
            }

            return MazeNumber;
        }

        public int AskInput()
        {
            int UserInput = 0;
            Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");
            ConsoleKey Input = Console.ReadKey().Key;
            Console.WriteLine("");
            switch (Input)
            {
                case ConsoleKey.UpArrow:
                    UserInput = (int)Direction.North;
                    break;

                case ConsoleKey.RightArrow:
                    UserInput = (int)Direction.East;
                    break;

                case ConsoleKey.DownArrow:
                    UserInput = (int)Direction.South;
                    break;

                case ConsoleKey.LeftArrow:
                    UserInput = (int)Direction.West;
                    break;

                case ConsoleKey.R:
                    UserInput = -2;
                    break;

                case ConsoleKey.S:
                    UserInput = -1;
                    break;

                default:
                    Console.WriteLine("Dit is geen geldige input");
                    UserInput = AskInput();
                    break;
            }

            return UserInput;
        }
    }
}