using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMapLoaderLib;
using System.Diagnostics;

namespace Bomberman.Model
{
    public delegate void ModelChangedHandler(List<List<IConsoleMapElement>> newMap, List<List<IConsoleMapElement>> oldMap);

    class GameModel
    {
        public event ModelChangedHandler ModelChangedEvent;

        private List<IConsoleMapElement> consoleMapElements;
        private ConsoleMapLoader mapLoader;

        private List<List<IConsoleMapElement>> curMap;
        private List<List<IConsoleMapElement>> newMap;
        private List<List<IConsoleMapElement>> oldMap;


        private List<Player> players;

        public GameModel()
        {
            this.consoleMapElements = new List<IConsoleMapElement>();
            this.consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.DarkRed, '#', '#', false));
            this.consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.Red, '+', '#', true));
            this.consoleMapElements.Add(new None(ConsoleColor.Black, ConsoleColor.Black, ' ', ' '));

            this.mapLoader = new ConsoleMapLoader("Maps", "cmap", this.consoleMapElements);
            this.newMap = new List<List<IConsoleMapElement>>();
        }

        public void LoadMap(string mapName) //TODO : Exception
        {
            if (this.mapLoader != null && mapName != null)
            {
                this.curMap = this.mapLoader.LoadMap(mapName);
            }
        }

        public void Run()
        {
            initializeGame();

        }

        public void PerformTick()
        {
            if (this.ModelChangedEvent != null)
                this.ModelChangedEvent(this.newMap, this.oldMap);
            this.oldMap = CopyList(this.newMap);

        }

        private List<List<IConsoleMapElement>> CopyList(List<List<IConsoleMapElement>> list)
        {
            List<List<IConsoleMapElement>> newList = new List<List<IConsoleMapElement>>();
            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(new List<IConsoleMapElement>());
                for (int j = 0; j < list[i].Count; j++)
                {
                    newList[i].Add(list[i][j]);
                }
            }
            return newList;
        }

        private void initializeMap()
        {
            this.newMap = CopyList(this.curMap); //oaschloch


            // Nur zum Test
            Dictionary<ConsoleKey, KeyBindings> bindingss = new Dictionary<ConsoleKey, KeyBindings>();
            bindingss.Add(ConsoleKey.W, KeyBindings.MoveUp);
            bindingss.Add(ConsoleKey.A, KeyBindings.MoveLeft);
            bindingss.Add(ConsoleKey.S, KeyBindings.MoveDown);
            bindingss.Add(ConsoleKey.D, KeyBindings.MoveRight);
            this.players = new List<Player>();
            players.Add(new Player(ConsoleColor.Black, ConsoleColor.Blue, '1', '1', new Point(1, 1), bindingss));
            this.newMap[players[0].Location.Y][players[0].Location.X] = players[0];

            this.oldMap = CopyList(this.newMap);
        }


        private void initializeGame()
        {
            initializeMap();

            if (this.ModelChangedEvent != null)
                this.ModelChangedEvent(this.newMap, null);
        }

    }
}
