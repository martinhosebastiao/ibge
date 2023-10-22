using System;

namespace IBGE.Api.Domain.Notifications
{
    public abstract class Notifiable : INotifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() => _notifications = new();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        /// <summary>
        /// Valida se foi adicionado alguma notificação de erro.
        /// Retorna um boolean True = Valido
        /// </summary>
        public bool HasValid => _notifications.Count == 0;

        public void Clear() => _notifications.Clear();

        public void AddNotification(string? key, string message)
        {
            var notification = new Notification(key ?? string.Empty, message);

            _notifications.Add(notification);
        }

        public void AddNotification(Type? property, string message)
            => AddNotification(property?.Name ?? string.Empty, message);

        public int GreaterOrEqualThan(int value1, int value2)
        {
            if (value1 >= value2) return value1;

            AddNotification(value1.ToString(), "Lower than expected");

            return 0;
        }

        public short GreaterOrEqualThan(short value1, short value2)
        {
            if (value1 >= value2) return value1;

            AddNotification(value1.ToString(), "Lower than expected");

            return 0;
        }

        public byte GreaterOrEqualThan(byte value1, byte value2)
        {
            if (value1 >= value2) return value1;
           
            AddNotification(value1.ToString(), "Lower than expected");

            return 0;
        }
    }
}
