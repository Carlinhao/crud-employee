using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class DepartmentRequest
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}
