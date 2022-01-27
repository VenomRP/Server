using Newtonsoft.Json;


namespace GVRP.Module.Computer.Apps.PoliceAktenSearchApp
{

    public class ReasonObject
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }

}
