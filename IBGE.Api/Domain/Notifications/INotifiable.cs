namespace IBGE.Api.Domain.Notifications
{
    public interface INotifiable
    {
        void AddNotification(string key, string message);
        void AddNotification(Type property, string message);

        int GreaterOrEqualThan(int value1, int value2);
        short GreaterOrEqualThan(short value1, short value2);
        byte GreaterOrEqualThan(byte value1, byte value2);
    }
}

