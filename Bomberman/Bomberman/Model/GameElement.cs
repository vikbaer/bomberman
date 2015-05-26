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
        public ConsoleColor BackGroundColor { get; set; }

        public ConsoleColor ForeGroundColor { get; set; }

        public char ReadSign { get; set; }
        public char Sign { get; set; }

        public GameElement(ConsoleColor backGroundColor, ConsoleColor foreGroundColor, char readSign, char sign)
        {
            this.BackGroundColor = backGroundColor;
            this.ForeGroundColor = foreGroundColor;
            this.ReadSign = readSign;
            this.Sign = sign;
        }
    }
}
