using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Crate : Movable
    {
        public char Symbol = 'o';

        public Crate(Tile tilewithCrate)
        {
            Location = tilewithCrate;
        }

        public bool IsOnGoal;

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

            if (nextTile.Content == null)
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