using System.Collections.Generic;
using System.Net;

namespace employers.application.Notifications
{
    public interface INotificationMessages
    {
        Notification AddNotification(string key, string message, HttpStatusCode statusCode);
        List<Notification> GetNotification(Notification notification);
        void Handle(Notification notification);
        bool HasNotification();
        List<Notification> Notications();
    }
}
