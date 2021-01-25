using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> filesInfo =
                new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo dirInfo = new DirectoryInfo("../../../");

            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (var file in fileInfo)
            {
                if (!filesInfo.ContainsKey(file.Extension))
                {
                    filesInfo.Add(file.Extension, new Dictionary<string, double>());
                }

                filesInfo[file.Extension].Add(file.Name, file.Length / 1000.0);
            }

            using (StreamWriter writer = new StreamWriter
                (@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DirectoryTraversal.txt"))
            {
                foreach (var item in filesInfo.OrderByDescending(f => f.Value.Count).ThenBy(i => i.Key))
                {
                    writer.WriteLine(item.Key);

                    foreach (var file in item.Value.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }


        }
    }
}
