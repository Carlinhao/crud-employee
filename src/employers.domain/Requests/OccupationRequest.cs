using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class OccupationRequest
    {
        [JsonPropertyName("name_occupation")]
        public string NameOccupation { get; set; }

        [JsonPropertyName("level_occupation")]
        public string LevelOccupation { get; set; }
    }
}
