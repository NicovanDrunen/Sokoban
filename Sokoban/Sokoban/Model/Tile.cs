using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public abstract class Tile
    {
        public char Symbol;

        public Tile TileWest;

        public Tile TileNorth;

        public Tile TileEast;

        public Tile TileSouth;

        public  Movable Content;

        public abstract void MoveTo(Movable movable);
    }
}