using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoUpdater
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Downloading and applying the update. Please wait and do not close this window...");

            FileDownloader downloader = new FileDownloader();

            string zipFilePath = "";

            // Download data and unpack
            try
            {
                // Download the file with progress reporting.
                await downloader.DownloadFileAsync(args[0], AppDomain.CurrentDomain.BaseDirectory);

                string filename = Path.GetFileName(args[0]);

                // Assuming the zip file is named 'steamcmd.zip' and is located in the downloadPath.
                zipFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                // Unpack the zip file
                await downloader.UnpackZipFileAsync(zipFilePath, AppDomain.CurrentDomain.BaseDirectory);
            }
            catch (Exception ex)
            {
                if(ex.Message == "Index was outside the bounds of the array.") Environment.Exit(0);

                Console.Clear();
                Console.WriteLine($"Please report this error:{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Delete file
            try
            {
                Thread.Sleep(2000);
                if (File.Exists(zipFilePath)) File.Delete(zipFilePath);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Please report this error:{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                Environment.Exit(0);
            }

            Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Steam Server Creation Tool V2.exe"));
        }
    }
}
