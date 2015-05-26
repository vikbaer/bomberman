using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMapLoaderLib;

namespace Bomberman.Model
{
    public delegate void ModelChangedHandler();
    class GameModel
    {
        private List<IConsoleMapElement> consoleMapElements;
        private ConsoleMapLoader mapLoader;

        public GameModel()
        {
            this.consoleMapElements = new List<IConsoleMapElement>();
            this.consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.DarkRed, '#', '#', false));
            this.consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.Red, '+', '#', true));
            this.consoleMapElements.Add(new None(ConsoleColor.Black, ConsoleColor.Black, ' ', ' '));

            this.mapLoader = new ConsoleMapLoader("Maps", "cmap", this.consoleMapElements);
        }
    }
}
