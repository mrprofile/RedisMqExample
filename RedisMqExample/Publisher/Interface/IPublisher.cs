namespace RedisMqExample.Publisher.Interface
{
    public interface IPublisher
    {
        void Publish(string id, string action);
        void Publish(string[] ids, string action);
    }
}