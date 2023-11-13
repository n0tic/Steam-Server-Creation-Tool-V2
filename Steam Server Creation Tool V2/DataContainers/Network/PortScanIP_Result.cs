using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Server_Creation_Tool_V2
{
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
