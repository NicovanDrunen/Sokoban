using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Blank : Tile
    {
        public Blank()
        {
            Symbol = ' ';
        }
        
        public override void MoveTo(Movable movable)
        {
        }
    }
}