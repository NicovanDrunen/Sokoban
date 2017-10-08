using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class SleepingSokoban : Movable
    {
        private bool _sleeping;
        private Random _r = new Random();
        public SleepingSokoban(Tile tileWithSleeplingSokoban)
        {
            Symbol = '$';
            Location = tileWithSleeplingSokoban;
            _sleeping = false;
        }

        public override void Push(Movable movable, Direction direction)
        {
            movable.Move(direction);
        }

        public override void Move(Direction direction)
        {
            if (!_sleeping)
            {
                Tile nextTile = new Floor();
                switch (direction)
                {
                    case Direction.North:
                        nextTile = Location.TileNorth;
                        break;
                    case Direction.East:
                        nextTile = Location.TileEast;
                        break;
                    case Direction.South:
                        nextTile = Location.TileSouth;
                        break;
                    case Direction.West:
                        nextTile = Location.TileWest;
                        break;
                }

                if (nextTile.Content != null)
                {
                    Push(nextTile.Content, direction);
                }
                if (nextTile.Content == null && nextTile.GetType() != typeof(Wall))
                {
                    nextTile.MoveTo(this);
                    Location.Content = null;
                    Location = nextTile;
                }
                if (_r.Next(4) == 0)
                {
                    _sleeping = true;
                    Symbol = 'Z';
                }
            }
            if (_sleeping && _r.Next(10) == 0)
            {
                WakeUp();
            }
        }

        public override void WakeUp()
        {
            _sleeping = false;
            Symbol = '$';
        }
    }
}