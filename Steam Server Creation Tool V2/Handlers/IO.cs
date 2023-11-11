using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2
{
    internal static class IO
    {
        public static async Task MoveFolderAsync(string sourceDirectoryName, string targetDirectoryName)
        {
            await Task.Run(() =>
            {
                Directory.CreateDirectory(targetDirectoryName);

                DirectoryInfo source = new DirectoryInfo(sourceDirectoryName);
                DirectoryInfo target = new DirectoryInfo(targetDirectoryName);

                MoveWork(source, target);

                foreach (var item in source.GetDirectories("*", SearchOption.AllDirectories))
                {
                    try
                    {
                        item.Delete(true);
                    }
                    catch { }
                }
            });
        }

        private static void MoveWork(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                MoveWork(dir, target.CreateSubdirectory(dir.Name));
            }

            foreach (FileInfo file in source.GetFiles())
            {
                file.MoveTo(Path.Combine(target.FullName, file.Name));
            }
        }
    }
}
