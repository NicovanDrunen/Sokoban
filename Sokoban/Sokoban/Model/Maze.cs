using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Maze
    {
        public Forklift Forklift;

        private List<Crate> _crates = new List<Crate>();

        private List<SleepingSokoban> _slpList = new List<SleepingSokoban>();

        private Random _r = new Random();

        public Tile firstTile;

        public bool IsSolved()
        {
            foreach (Crate crate in _crates)
            {
                if (crate.IsOnGoal == false)
                {
                    return false;
                }
            }
            return true;
        }

        public Crate addCrate(Crate crate)
        {
            _crates.Add(crate);
            return crate;
        }

        public SleepingSokoban AddSleepingSokoban(SleepingSokoban sleepingSokoban)
        {
            _slpList.Add(sleepingSokoban);
            return sleepingSokoban;
        }

        public void MoveSleepingSokobans()
        {
            foreach (SleepingSokoban sleepingSokoban in _slpList)
            {
                sleepingSokoban.Move((Direction)Enum.GetValues(typeof(Direction)).GetValue(_r.Next(Enum.GetValues(typeof(Direction)).Length)));
            }
        }
    }
}