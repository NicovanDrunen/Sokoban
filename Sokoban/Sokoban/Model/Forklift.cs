using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Forklift : Movable
    {
        public Forklift(Tile tileWithForklift)
        {
            Symbol = '@';
            Location = tileWithForklift;
        }

        public override void Push(Movable movable, Direction direction)
        {
            if (movable.GetType() == typeof(Crate))
            {
                movable.Move(direction);
            }
            movable.WakeUp();
        }

        public override void Move(Direction direction)
        {
            Tile nextTile;
            switch(direction)
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
                default:
                    nextTile = Location;
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
        }

        public override void WakeUp()
        {
        }
    }
}