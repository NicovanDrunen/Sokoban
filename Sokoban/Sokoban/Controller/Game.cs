using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Model;
using Sokoban.View;

namespace Sokoban.Controller
{
    public class Game
    {
        private bool _isGameOver = false;
        private int _numberOfMoves = 0;
        private InputView _inputView;
        private OutputView _outputView;
        private Maze _maze;

        public Game()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
        }


        public void Start()
        {
            bool ShowStart = true;

            while (!_isGameOver)
            {
                if (ShowStart)
                {
                    _outputView.ShowStartGame();
                    int MazeNumber = _inputView.AskMazeNumber();
                    if (MazeNumber == -1)
                    {
                        _outputView.ShowStopGame();
                        break;
                    }
                    Parser parser = new Parser();
                    _maze = parser.LoadMaze(MazeNumber);
                    //test();
                    ShowStart = false;
                }
                _outputView.ShowMaze(_maze);
                int UserInput = _inputView.AskInput();
                if (UserInput == -2)
                {
                    ShowStart = true;
                }
                else if (UserInput == -1)
                {
                    _outputView.ShowStopGame();
                    _isGameOver = true;
                }
                else
                {
                    _maze.Forklift.Move((Direction) UserInput);
                    _numberOfMoves++;
                    if (_maze.IsSolved())
                    {
                        _isGameOver = true;
                        _outputView.ShowMaze(_maze);
                        _outputView.ShowEndGame(_numberOfMoves);
                    }
                }
            }
        }

        public void test()
        {
            Wall wall1 = new Wall();
            Goal floor1 = new Goal();
            Floor floor2 = new Floor();
            Floor floor3 = new Floor();
            Floor floor4 = new Floor();
            Floor floor5 = new Floor();
            wall1.TileEast = floor1;
            floor1.TileEast = floor2;
            floor1.TileSouth = floor5;
            floor1.TileWest = wall1;
            floor2.TileWest = floor1;
            floor3.TileWest = floor2;
            floor2.TileEast = floor3;
            wall1.TileSouth = floor4;
            floor4.TileEast = floor5;
            floor5.TileWest = floor4;
            floor4.TileNorth = wall1;
            floor5.TileNorth = floor1;
            _maze.firstTile = wall1;
            Forklift fl = new Forklift(floor3);
            floor3.Content = fl;
            _maze.Forklift = fl;
            Crate crate = new Crate(floor2);
            floor2.Content = crate;
            _maze.addCrate(crate);
        }

    }
}