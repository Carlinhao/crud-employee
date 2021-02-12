using System.Net;
using System.Text.Json.Serialization;

namespace employers.application.Notifications
{
    public class Notification
    {
        public Notification(string message, string key, HttpStatusCode statusCode )
        {
            Message = message;
            Key = key;
            StatusCode = statusCode;
        }

        public string Message { get; set; }
        public string Key { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}
