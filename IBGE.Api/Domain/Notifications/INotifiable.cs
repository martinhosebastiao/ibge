namespace IBGE.Api.Domain.Notifications
{
    public interface INotifiable
	{
		void AddNotification(string key, string message);
        void AddNotification(Type property, string message);
        void AddNotifications(IEnumerable<Notification> notifications);
        void AddNotifications(ICollection<Notification> notifications);
        void AddNotifications(IList<Notification> notifications);
    }
}

