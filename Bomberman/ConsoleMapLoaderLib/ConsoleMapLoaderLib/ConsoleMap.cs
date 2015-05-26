using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleMapLoaderLib
{
    public interface IConsoleMapElement
    {
        ConsoleColor BackGroundColor { get; set; }
        ConsoleColor ForeGroundColor { get; set; }
        char ReadSign { get; set; }
        char Sign { get; set; }
    }
    class ConsoleMap
    {
        #region VARIABLES & PROPERTIES
        /*************************************************/
        public const int MIN_WIDTH = 10;
        public const int MAX_WIDTH = 170;
        public const int MIN_HEIGHT = 10;
        public const int MAX_HEIGHT = 58;

        private List<List<IConsoleMapElement>> map = new List<List<IConsoleMapElement>>();

        internal List<List<IConsoleMapElement>> Map //TODO: Zugriff auf nicht initialisierte Variable verhindern - Exception 
        {
            get
            {
                if (map == null)
                    return default(List<List<IConsoleMapElement>>);
                return map;
            }
            set
            {
                if (value != null && value.Count > 0)
                    if (!(value.Count < MIN_WIDTH || value.Count > MAX_WIDTH || value[0].Count < MIN_HEIGHT || value[9].Count > MAX_HEIGHT))
                        map = value;
            }
        }

        private List<IConsoleMapElement> consoleMapElements;



        /*************************************************/
        #endregion VARIABLES & PROPERTIES


        #region CONSTRUCTING & INITIALIZING
        /*************************************************/
        public ConsoleMap(List<IConsoleMapElement> consoleMapElements)
        {
            this.consoleMapElements = consoleMapElements;
        }

        /*************************************************/
        #endregion CONSTRUCTING & INITIALIZING


        #region FUNCTIONS
        /*************************************************/
        public List<List<IConsoleMapElement>> LoadMap(string path)
        {
            if (!loadMap(path))
            {
                return default(List<List<IConsoleMapElement>>);
            }
            return this.Map;
        }

        private bool loadMap(string path)
        {
            bool check; //TODO : besser benennen
            string line;
            int lineLength = 0;

            if (!File.Exists(path))
                return false;

            using (StreamReader streamReader = new StreamReader(path, Encoding.Default))
            {
                if (streamReader.EndOfStream)
                {
                    streamReader.Close();
                    return false;
                }

                line = streamReader.ReadLine();
                lineLength = line.Length;

                for (int i = 0; i < MAX_HEIGHT; i++)
                {


                    if (lineLength != line.Length)
                        return false;

                    if (line.Length < MIN_WIDTH || line.Length > MAX_WIDTH)
                    {
                        return false;
                    }

                    map.Add(new List<IConsoleMapElement>());

                    for (int j = 0; j < line.Length; j++)
                    {
                        check = false;
                        for (int k = 0; k < consoleMapElements.Count; k++)
                        {
                            if ((line[j] == consoleMapElements[k].ReadSign))
                            {
                                this.map[i].Add(consoleMapElements[k]);
                                check = true;
                                break;
                            }
                        }
                        if (check == false)
                            return false;
                    }

                    if (streamReader.EndOfStream)
                    {
                        streamReader.Close();
                        if (i < MIN_WIDTH)
                            return false;
                        return true;
                    }

                    line = streamReader.ReadLine();


                }

                return true;
            }
        }

        /*************************************************/
        #endregion FUNCTIONS
    }
}
