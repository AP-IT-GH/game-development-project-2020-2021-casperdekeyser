using System;
using System.Diagnostics;

namespace MakingAPlatformer.Map
{
    public class TiledInterpreter // not used, too complex
    {
        private string _tiledPath = @"C:\GitHub\game-development-project-2020-2021-casperdekeyser\MakingAPlatformer\Map\Tiled\Death.tmx";
        public TiledInterpreter()
        {
            ParseMatrix();
        }

        public void ReadTmxFile()
        {
            string[] lines = System.IO.File.ReadAllLines(_tiledPath);
            for (int i = 5; i < 20; i++)
            {
                lines[i] = "{" + lines[i] + "}";
                Debug.Write(lines[i]);
            }

        }

        public void ParseMatrix()
        {
            string[] matrix =
            {
                "0,0,0,1,1,1,1,0,0,0,1,0,0,0,1,1,1,1,0,1,0,0,1,0,0,",
                "0,0,1,0,1,1,1,0,1,1,1,1,0,1,0,0,0,1,0,1,0,0,0,0,0,"
            };

            string line = "0,0,0,1,1,1,1,0,0,0,1,0,0,0,1,1,1,1,0,1,0,0,1,0,0,";
            string[] splittedArr = line.Split(",");

            int[] intArr = new int[splittedArr.Length-1];
            for (int i = 0; i < splittedArr.Length; i++)
            {
                if(!String.IsNullOrEmpty(splittedArr[i])) intArr[i] = Int32.Parse(splittedArr[i]);
            }

            foreach (int item in intArr)
            {
                Debug.WriteLine("int: " + item);
            }

            string[,] splittedMatrix = new string[25,matrix.Length];
        }
    }
}
