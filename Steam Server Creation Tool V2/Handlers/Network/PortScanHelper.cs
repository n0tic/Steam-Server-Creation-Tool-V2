using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Steam_Server_Creation_Tool_V2
{
    public static class PortScanHelper
    {
        static string ipURL = "https://bytevaultstudio.se/PortScan/portscan.php";
        static string portURL = "https://bytevaultstudio.se/PortScan/portscan.php?ip=X&port=Y";

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
