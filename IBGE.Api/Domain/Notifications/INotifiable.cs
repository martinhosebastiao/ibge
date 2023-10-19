namespace IBGE.Api.Domain.Notifications
{
    public interface INotifiable
	{
		void AddNotification(string key, string message);
        void AddNotification(Type property, string message);
    }
}

