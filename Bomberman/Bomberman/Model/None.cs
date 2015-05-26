using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    class None : GameElement
    {
        public None(ConsoleColor backGroundColor, ConsoleColor foreGroundColor, char readSign, char sign)
            : base(backGroundColor, foreGroundColor, readSign, sign)
        {

        }
    }
}
