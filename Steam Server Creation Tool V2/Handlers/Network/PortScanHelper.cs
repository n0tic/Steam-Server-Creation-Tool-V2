using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Class to help with portscan
    /// </summary>
    public static class PortScanHelper
    {
        static string ipURL = "https://bytevaultstudio.se/PortScan/portscan.php";
        static string portURL = "https://bytevaultstudio.se/PortScan/portscan.php?ip=X&port=Y";

        /// <summary>
        /// Get IP from the user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<PortScanIP_Result> GetIpAddressAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(ipURL);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PortScanIP_Result result = JsonConvert.DeserializeObject<PortScanIP_Result>(jsonResponse);

                    return result;
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"Error fetching IP address: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Get portscan results
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<PortScanIP_Result> GetPortScanAsync(string ip, string port)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = portURL
                    .Replace("X", $"{ip}")
                    .Replace("Y", $"{port}");

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(jsonResponse);

                    PortScanIP_Result result = JsonConvert.DeserializeObject<PortScanIP_Result>(jsonResponse);

                    return result;
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"Error fetching IP address: {ex.Message}");
                }
            }
        }
    }
}
