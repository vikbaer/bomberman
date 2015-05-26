using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMapLoaderLib;

namespace Bomberman.Model
{
    class GameElement : IConsoleMapElement
    {
        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public char ReadSign { get; set; }
        public char Sign { get; set; }

        public GameElement(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char readSign, char sign)
        {
            this.BackgroundColor = backgroundColor;
            this.ForegroundColor = foregroundColor;
            this.ReadSign = readSign;
            this.Sign = sign;
        }
    }
}
