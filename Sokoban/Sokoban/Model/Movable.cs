using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public abstract class Movable
    {
        public char Symbol;

        public Tile Location;

        public abstract void Push(Movable movable, Direction direction);
        public abstract void Move(Direction direction);

        public abstract void WakeUp();
    }
}