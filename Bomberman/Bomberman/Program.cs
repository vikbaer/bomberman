using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleKeyHookLib;
using ConsoleMapLoaderLib;
using Bomberman.Model;

namespace Bomberman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConsoleMapElement> consoleMapElements = new List<IConsoleMapElement>();
            consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.DarkRed, '#', '#', false));
            consoleMapElements.Add(new Wall(ConsoleColor.Black, ConsoleColor.Red, '+', '#', true));
            consoleMapElements.Add(new None(ConsoleColor.Black, ConsoleColor.Black, ' ', ' '));
            ConsoleMapLoader mapLoader = new ConsoleMapLoader("Maps", "cmap", consoleMapElements);
            DrawMap(mapLoader.LoadMap("map1"));

            Console.ReadLine();
        }

        static void DrawMap(List<List<IConsoleMapElement>> map)
        {
            if (map == default(List<List<IConsoleMapElement>>))
                return;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.BackgroundColor = map[i][j].BackGroundColor;
                    Console.ForegroundColor = map[i][j].ForeGroundColor;
                    Console.Write(map[i][j].Sign);
                }
            }
        }
    }
   
    

    

   


}
