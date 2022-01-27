using Newtonsoft.Json;

namespace GVRP.Module.Computer.Apps.PoliceAktenSearchApp
{
    public class CategoryObject
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }
}
