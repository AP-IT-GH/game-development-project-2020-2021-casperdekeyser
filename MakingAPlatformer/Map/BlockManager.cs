using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MakingAPlatformer.Map
{
    public static class BlockManager
    {
        public static List<string> BlockTypeNames = new List<string>();

        public static void LoadBlocks()
        {
            GetFileNamesFromPath(GetAllFiles(@"C:\GitHub\game-development-project-2020-2021-casperdekeyser\MakingAPlatformer\Map\Blocks", "*.cs"));
        }

        private static IEnumerable<string> GetAllFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern).Union(
            Directory.EnumerateDirectories(path).SelectMany(d =>
            {
                try
                {
                    return GetAllFiles(d, searchPattern);
                }
                catch (Exception)
                {
                    return Enumerable.Empty<string>();
                }
            }));
        }

        private static void GetFileNamesFromPath(IEnumerable<string> pathNames)
        {
            Regex rx = new Regex(@"\w*\.cs");

            foreach (string path in pathNames)
            {
                string fullFileName = rx.Match(path).ToString();
                string fileName = fullFileName[0..^3]; // remove last 3 chars
                Debug.WriteLine(fileName);

                BlockTypeNames.Add(fileName);
            }
        }
    }
}
