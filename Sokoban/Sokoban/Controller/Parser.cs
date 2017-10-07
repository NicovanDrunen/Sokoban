using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Model;
using System.IO;

namespace Sokoban.Controller
{
    public class Parser
    {
        private Maze _maze;
        private FileStream _inputStream;
        private StreamReader _reader;
        private string _path;

        public Maze LoadMaze(int mazeNumber)
        {
            _maze = new Maze();
            _path = String.Concat("..\\..\\Resources\\doolhof", mazeNumber, ".txt");
            try
            {
                _inputStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                _reader = new StreamReader(_inputStream);
                //Get first line from File.
                string lineString = _reader.ReadLine();
                do
                {
                    //Huidige werking: Leest alle lijnen en overschrijdt steeds de vorige lijn als nieuwe lijn. De laatste lijn in het gekozen bestand wordt dus als enige uitgelezen.
                    char[] charsInLine = lineString.ToCharArray();
                    Tile previousTile = null;
                    Tile currentTile = null;
                    for (int i = 0; i < charsInLine.Length; i++)
                    {
                        switch (charsInLine[i])
                        {
                            case '#':
                                currentTile = new Wall();
                                break;
                            default:
                                currentTile = new Floor();
                                break;
                        }
                        if (previousTile == null)
                        {
                            _maze.firstTile = currentTile;
                            previousTile = currentTile;
                        }
                        else
                        {
                            previousTile.TileEast = currentTile;
                            previousTile = currentTile;
                        }

                    }
                    //get next line from file
                    lineString = _reader.ReadLine();
                }
                while (lineString != null);

                //close both streams after reading file
                _reader.Close();
                _inputStream.Close();

                return _maze;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}