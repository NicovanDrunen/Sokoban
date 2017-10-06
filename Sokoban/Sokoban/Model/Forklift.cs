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
        public char Symbol = '@';

        public Forklift(Tile tileWithForklift)
        {
            Location = tileWithForklift;
        }

        public void Push(Movable crate, Direction direction)
        {
            crate.Move(direction);
        }

        public override void Move(Direction direction)
        {
            Tile nextTile = new Floor();
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
            }

            if (nextTile.Content.GetType() == typeof(Crate))
            {
                Push(nextTile.Content, direction);
            }
            if (nextTile.Content == null)
            {
                nextTile.MoveTo(this);
                Location.Content = null;
                Location = nextTile;
            }
        }
    }
}