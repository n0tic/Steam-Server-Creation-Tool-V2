using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AutoUpdater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpdateHelper downloader = new UpdateHelper();

            if (args.Length < 1 || !downloader.IsValidUrl(args[0]))
            {
                Console.WriteLine("Invalid argument. Exiting...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            Console.WriteLine("Please wait while the update is being prepared... This should only take a few seconds...");

            // Initiate variable
            string zipFilePath = "";

            // Download data and unpack
            try
            {
                // Download the file with progress reporting.
                downloader.DownloadFile(args[0], AppDomain.CurrentDomain.BaseDirectory);

                //Get filename
                string filename = Path.GetFileName(args[0]);

                // Assuming the zip file is named 'steamcmd.zip' and is located in the downloadPath.
                zipFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                // Unpack the zip file
                downloader.UnpackZipFile(zipFilePath, AppDomain.CurrentDomain.BaseDirectory);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Please report this error:{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Delete file
            try
            {
                //Wait one second
                Thread.Sleep(1000);
                //Try deleting file
                if (File.Exists(zipFilePath)) File.Delete(zipFilePath);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Please report this error:{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Steam Server Creation Tool V2.exe"));
        }
    }
}
