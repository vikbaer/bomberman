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
        public Wall(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char readSign, char sign, bool isDestructable)
            : base(backgroundColor, foregroundColor, readSign, sign)
        {
            this.IsDestructable = isDestructable;
        }
    }
}
