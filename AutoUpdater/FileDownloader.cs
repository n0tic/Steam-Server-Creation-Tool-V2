using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoUpdater
{
    public class FileDownloader
    {
        public void DownloadFile(string fileUrl, string destinationPath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead).Result)
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException($"The request did not complete successfully and returned status code {response.StatusCode}.");
                    }

                    var contentLength = response.Content.Headers.ContentLength;

                    using (var streamToReadFrom = response.Content.ReadAsStreamAsync().Result)
                    {
                        string fileName = Path.GetFileName(fileUrl);
                        string destinationFilePath = Path.Combine(destinationPath, fileName);

                        using (var streamToWriteTo = File.Open(destinationFilePath, FileMode.Create))
                        {
                            var buffer = new byte[8192]; // 8KB buffer.
                            var isMoreToRead = true;

                            do
                            {
                                var read = streamToReadFrom.Read(buffer, 0, buffer.Length);
                                if (read == 0)
                                {
                                    isMoreToRead = false;
                                    continue;
                                }

                                streamToWriteTo.Write(buffer, 0, read);
                            }
                            while (isMoreToRead);
                        }
                    }
                }
            }
        }

        public void UnpackZipFile(string zipFilePath, string extractPath)
        {
            using (var zipToOpen = new FileStream(zipFilePath, FileMode.Open))
            using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                var totalEntries = archive.Entries.Count;
                var entriesProcessed = 0;

                foreach (var entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(extractPath, entry.FullName);

                    string destinationDirectory = Path.GetDirectoryName(destinationPath);
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    try
                    {
                        entry.ExtractToFile(destinationPath, true);
                    }
                    catch { }

                    entriesProcessed++;
                    var calculatedProgress = (double)entriesProcessed / totalEntries;
                }
            }
        }
    }


}
