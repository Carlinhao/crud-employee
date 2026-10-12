using System.Net;
using System.Text.Json.Serialization;

namespace employers.application.Notifications;

public class Notification(string message, string key, HttpStatusCode statusCode)
{
    public string Message { get; set; } = message;
    public string Key { get; set; } = key;

    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}
