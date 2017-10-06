using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Forklift : Movable
    {
        public char Symbol = '@';

        public void Push(Crate crate)
        {
            throw new System.NotImplementedException();
        }

        public void Move(Crate crate)
        {
            throw new NotImplementedException();
        }

        public override void Move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}