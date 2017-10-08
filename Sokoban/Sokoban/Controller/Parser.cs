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
                Tile previousRowTile = null;
                Tile upperTile = null;
                do
                {
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
                            case ' ':
                                currentTile = new Blank();
                                break;
                            case 'x':
                                currentTile = new Goal();
                                break;
                            case '@':
                                currentTile = new Floor();
                                _maze.Forklift = new Forklift(currentTile);
                                currentTile.Content = _maze.Forklift;
                                break;
                            case 'o':
                                currentTile = new Floor();
                                currentTile.Content = _maze.addCrate(new Crate(currentTile));
                                break;
                            case '~':
                                currentTile = new Broken();
                                break;
                            case '$':
                                currentTile = new Floor();
                                currentTile.Content = _maze.AddSleepingSokoban(new SleepingSokoban(currentTile));
                                break;
                            default:
                                currentTile = new Floor();
                                break;
                        }
                        if (previousTile == null && previousRowTile == null)
                        {
                            _maze.firstTile = currentTile;
                            previousTile = currentTile;
                        }
                        else if (previousTile != null && previousRowTile == null)
                        {
                            previousTile.TileEast = currentTile;
                            currentTile.TileWest = previousTile;
                            previousTile = currentTile;
                        }
                        else if (previousTile == null && previousRowTile != null)
                        {
                            currentTile.TileNorth = upperTile;
                            upperTile.TileSouth = currentTile;
                            upperTile = upperTile.TileEast;
                            previousTile = currentTile;
                        }
                        else
                        {
                            currentTile.TileNorth = upperTile;
                            upperTile.TileSouth = currentTile;
                            previousTile.TileEast = currentTile;
                            currentTile.TileWest = previousTile;
                            upperTile = upperTile.TileEast;
                            previousTile = currentTile;
                        }

                    }
                    if (previousRowTile == null)
                    {
                        previousRowTile = _maze.firstTile;
                    }
                    else
                    {
                        previousRowTile = previousRowTile.TileSouth;
                    }
                    upperTile = previousRowTile;
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