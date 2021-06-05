using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class OccupationUpdateRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name_occupation")]
        public string NameOccupation { get; set; }

        [JsonPropertyName("level_occupation")]
        public string LevelOccupation { get; set; }
    }
}
