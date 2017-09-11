using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Tile
    {
        public Crate Crate
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