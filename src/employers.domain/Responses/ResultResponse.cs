using System.Text.Json.Serialization;

namespace employers.domain.Responses
{
    public class ResultResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
