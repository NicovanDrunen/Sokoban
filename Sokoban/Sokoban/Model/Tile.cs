using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public abstract class Tile
    {
        public int Symbol;

        public Tile TileWest
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Tile TileNorth
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Tile TileEast
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Tile TileSouth
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract Movable Content
        {
            get;

            set;
        }

        public abstract void MoveTo(Movable movable);
    }
}