using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    class Wall : GameElement
    {
        public bool IsDestructable { get; set; }
        public Wall(ConsoleColor backGroundColor, ConsoleColor foreGroundColor, char readSign, char sign, bool isDestructable)
            : base(backGroundColor, foreGroundColor, readSign, sign)
        {
            this.IsDestructable = isDestructable;
        }
    }
}
