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
        private Maze _maze = new Maze();

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
                    if (MazeNumber == 0)
                    {
                        _outputView.ShowStopGame();
                        break;
                    }
                    Parser parser = new Parser();
                    parser.LoadMaze(MazeNumber);
                    ShowStart = false;
                }
                _outputView.ShowMaze();
                int UserInput = _inputView.AskInput();
                if (UserInput == -1)
                {
                    ShowStart = true;
                }
                else if (UserInput == 0)
                {
                    _outputView.ShowStopGame();
                    _isGameOver = true;
                }
                else
                {
                    _maze.Forklift.Move((Direction) UserInput);
                    Console.WriteLine("forlift bewogen naar" + (Direction) UserInput);
                    if (_maze.IsSolved())
                    {
                        _isGameOver = true;
                        _outputView.ShowEndGame(_numberOfMoves);
                    }
                }
            }
        }
    }
}