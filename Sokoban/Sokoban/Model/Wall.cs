using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Wall : Tile
    {
        public Wall()
        {
            Symbol = '█';
        }
        
        public override void MoveTo(Movable movable)
        {
        }
    }
}