using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleKeyHookLib;
using ConsoleMapLoaderLib;
using Bomberman.Model;
using System.Diagnostics;

namespace Bomberman
{
    class Program
    {
        static void Main(string[] args)
        {


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
                    Console.BackgroundColor = map[i][j].BackgroundColor;
                    Console.ForegroundColor = map[i][j].ForegroundColor;
                    Console.Write(map[i][j].Sign);
                }
            }
        }
    }
   
    

    

   


}
