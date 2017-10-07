using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Crate : Movable
    {

        public Crate(Tile tilewithCrate)
        {
            Symbol = 'o';
            Location = tilewithCrate;
        }

        public bool IsOnGoal = false;

        public override void Move(Direction direction)
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

            if (nextTile.Content == null && nextTile.GetType() != typeof(Wall))
            {
                nextTile.MoveTo(this);
                Location.Content = null;
                Location = nextTile;
            }
            if (Location.GetType() == typeof(Goal))
            {
                IsOnGoal = true;
                Symbol = '0';
            }
            else
            {
                IsOnGoal = false;
                Symbol = 'o';
            }
        }
    }
}