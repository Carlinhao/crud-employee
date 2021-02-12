using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace employers.application.Notifications
{
    public class NotificationMessages : INotificationMessages
    {
        private List<Notification> _notifications;
        private Notification Notification;
        public NotificationMessages()
        {
            _notifications = new List<Notification>();
        }
        public Notification AddNotification(string key, string message, HttpStatusCode statusCode)
        {
            _notifications.Add(new Notification(message, key, statusCode));
            return _notifications.FirstOrDefault();
        }

        public List<Notification> GetNotification(Notification notification)
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();             
        }

        public List<Notification> Notications()
        {
            return _notifications;             
        }
    }
}
