using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2
{
    public class FileDownloader
    {
        public async Task DownloadFileAsync(string fileUrl, string destinationPath, IProgress<double> progress)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send a GET request to the specified Uri as an asynchronous operation.
                using (HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    // Ensure we got a successful response.
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException($"The request did not complete successfully and returned status code {response.StatusCode}.");
                    }

                    // Get the total content length of the response.
                    var contentLength = response.Content.Headers.ContentLength;

                    using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        string fileName = Path.GetFileName(fileUrl);
                        string destinationFilePath = Path.Combine(destinationPath, fileName);

                        // Create a new file stream where we will be saving the data (file).
                        using (var streamToWriteTo = File.Open(destinationFilePath, FileMode.Create))
                        {
                            var totalRead = 0L;
                            var buffer = new byte[8192]; // 8KB buffer.
                            var isMoreToRead = true;

                            do
                            {
                                // Read from the web response in chunks.
                                var read = await streamToReadFrom.ReadAsync(buffer, 0, buffer.Length);
                                if (read == 0)
                                {
                                    isMoreToRead = false;
                                    progress.Report(1); // 100% completion.
                                    continue;
                                }

                                // Write the data to the file stream.
                                await streamToWriteTo.WriteAsync(buffer, 0, read);

                                // Calculate the progress and report it.
                                totalRead += read;
                                var calculatedProgress = (double)totalRead / contentLength.Value;
                                progress.Report(calculatedProgress);
                            }
                            while (isMoreToRead);
                        }
                    }
                }
            }
        }

        public async Task UnpackZipFileAsync(string zipFilePath, string extractPath, IProgress<double> progress)
        {
            await Task.Run(() =>
            {
                using (var zipToOpen = new FileStream(zipFilePath, FileMode.Open))
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    // Retrieve the total count of entries in the archive.
                    var totalEntries = archive.Entries.Count;
                    var entriesProcessed = 0;

                    // Loop through each file in the zip.
                    foreach (var entry in archive.Entries)
                    {
                        // Combine the base folder with the entry name to get the full path to extract to.
                        string destinationPath = Path.Combine(extractPath, entry.FullName);

                        // Ensure the directory exists.
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        // Extract the entry to the specified path.
                        entry.ExtractToFile(destinationPath, true);

                        // Calculate the progress and report it.
                        entriesProcessed++;
                        var calculatedProgress = (double)entriesProcessed / totalEntries;
                        progress.Report(calculatedProgress);
                    }
                }
            });
        }
    }


}
