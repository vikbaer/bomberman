using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    class Player : GameElement
    {
        public Point Location { get; set; }
        public Dictionary<ConsoleKey,KeyBindings> Bindings { get; set; } 
        public Player(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char readSign, char sign, Point location, Dictionary<ConsoleKey,KeyBindings> bindings)
            : base(backgroundColor, foregroundColor, readSign, sign)
        {
            this.Bindings = bindings;
            this.Location = location;
        }
    }
}
