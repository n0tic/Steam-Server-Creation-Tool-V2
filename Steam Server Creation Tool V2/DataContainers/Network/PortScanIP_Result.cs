namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Hold data about IP and UDP/TCP results for port sent
    /// </summary>
    public class PortScanIP_Result
    {
        public string IP { get; set; }
        public string TCP { get; set; }
        public string UDP { get; set; }

        public override string ToString()
        {
            return $"{IP}\n{TCP}\n{UDP}";
        }
    }
}
