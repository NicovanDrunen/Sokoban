using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public abstract class Movable
    {
        public Tile Location;

        public abstract void Move(Direction direction);
    }
}