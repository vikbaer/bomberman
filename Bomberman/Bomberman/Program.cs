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
            GameModel model = new GameModel();
            model.ModelChangedEvent += model_ModelChangedEvent;
            model.LoadMap("map1");
            model.Run();

            while (true)
            {
                model.PerformTick();
                System.Threading.Thread.Sleep(500);
            }

             Console.ReadLine();
        }

        static void model_ModelChangedEvent(List<List<IConsoleMapElement>> newMap, List<List<IConsoleMapElement>> oldMap)
        {
            if(oldMap == null)
            {
                for (int i = 0; i < newMap.Count; i++)
                {
                    for (int j = 0; j < newMap[i].Count; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.BackgroundColor = newMap[i][j].BackgroundColor;
                        Console.ForegroundColor = newMap[i][j].ForegroundColor;
                        Console.Write(newMap[i][j].Sign);
                    }
                }
            }
            else
            {
                for (int i = 0; i < newMap.Count; i++)
                {
                    for (int j = 0; j < newMap[i].Count; j++)
                    {
                        if (newMap[i][j] != oldMap[i][j])
                        {
                            Console.SetCursorPosition(j, i);
                            Console.BackgroundColor = newMap[i][j].BackgroundColor;
                            Console.ForegroundColor = newMap[i][j].ForegroundColor;
                            Console.Write(newMap[i][j].Sign);
                        }
                    }
                }
            }
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
