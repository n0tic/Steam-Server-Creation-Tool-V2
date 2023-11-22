using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Steam_Server_Creation_Tool_V2
{
    /// <summary>
    /// Convert data for github release
    /// </summary>
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
