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
    }
}