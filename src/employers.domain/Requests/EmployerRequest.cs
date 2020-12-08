using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class EmployerRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id_department")]
        public int IdDepartment { get; set; }
    }
}
