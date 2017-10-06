﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Floor : Tile
    {
        public char Symbol = '.';

        public override Movable Content { get; set; }

        public override void MoveTo(Movable movable)
        {
            Content = movable;
        }
    }
}