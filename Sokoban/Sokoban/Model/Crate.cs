using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Crate : Movable
    {
        public char Symbol = 'o';

        public bool IsOnGoal
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public override void Move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}