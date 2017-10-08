using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Broken : Tile
    {
        private int _movements = 0;
        public Broken()
        {
            Symbol = '~';
        }
        public override void MoveTo(Movable movable)
        {
            Content = movable;
            if (movable.GetType() == typeof(Crate) && _movements >= 3)
            {
                Content = null;
            }
            _movements++;
            if (_movements == 3)
            {
                Symbol = ' ';
            }
        }
    }
}