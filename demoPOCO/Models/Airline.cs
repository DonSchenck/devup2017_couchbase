using System;
using Newtonsoft.Json;

namespace demoPOCO.Models
{
    [Serializable]
    public class Airline
    {
        [JsonProperty("id")]
        public string Id {get;set;}
        [JsonProperty("type")]
        public string Type {get;set;}
        [JsonProperty("name")]
        public string Name {get;set;}
        [JsonProperty("iata")]
        public string Iata {get;set;}
        [JsonProperty("icao")]
        public string Icao {get;set;}
        [JsonProperty("callsign")]
        public string Callsign {get;set;}
        [JsonProperty("country")]
        public string Country {get;set;}
    }
}