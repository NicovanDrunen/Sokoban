﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Tile
    {
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

        protected abstract void MoveTo();

        protected abstract void MoveCrateTo();
    }
}