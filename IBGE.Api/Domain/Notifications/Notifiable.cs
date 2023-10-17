using System;

namespace IBGE.Api.Domain.Notifications
{
    public abstract class Notifiable : INotifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() => _notifications = new();

        public bool HasValid => _notifications.Any() == false;

        public void Clear() => _notifications.Clear();

        public void AddNotification(string key, string message)
        {
            var notification = new Notification(key, message);

            _notifications.Add(notification);
        }

        public void AddNotification(Type property, string message)
        {
            AddNotification(property?.Name ?? "", message);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            throw new NotImplementedException();
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            throw new NotImplementedException();
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            throw new NotImplementedException();
        }
    }
}

