﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    class None : GameElement
    {
        public None(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char readSign, char sign)
            : base(backgroundColor, foregroundColor, readSign, sign)
        {

        }
    }
}
