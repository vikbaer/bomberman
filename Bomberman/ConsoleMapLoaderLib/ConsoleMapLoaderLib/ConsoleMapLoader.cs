using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleMapLoaderLib
{
    public class ConsoleMapLoader
    {
        public string RootDirectory { get; private set; }
        public string FileExtension { get; private set; }
        public List<IConsoleMapElement> ConsoleMapElements { get; private set; }

        public ConsoleMapLoader(string rootDirectory, string fileExtension, List<IConsoleMapElement> consoleMapElements)
        {
            this.RootDirectory = rootDirectory;
            this.FileExtension = fileExtension;
            this.ConsoleMapElements = consoleMapElements;
        }

        public string[] GetMapNames() // TODO : Besser benennen
        {
            string[] mapNames = Directory.GetFiles(RootDirectory, "*." + FileExtension);
            for (int i = 0; i < mapNames.Length; i++)
                mapNames[i] = getFileName(mapNames[i]);
            return mapNames;
        }

        private string getFileName(string path) // TODO : Besser benennen
        {
            string fileName = path.Substring(path.LastIndexOf('\\') + 1);
            return fileName.Substring(0, fileName.LastIndexOf('.'));
        }

        public List<List<IConsoleMapElement>> LoadMap(string mapName)
        {
            ConsoleMap consoleMap = new ConsoleMap(this.ConsoleMapElements);
            return consoleMap.LoadMap(String.Format(@"{0}\{1}.{2}", this.RootDirectory, mapName, this.FileExtension)); //TODO : Überprüfung - letztes Zeichen von RootDirectory muss \ sein.
        }


    }
}
