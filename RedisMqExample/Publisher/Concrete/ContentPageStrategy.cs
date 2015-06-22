using Raven.Client;
using RedisMqExample.Publisher.Interface;

namespace RedisMqExample.Publisher.Concrete
{
    public class ContentPagePublisher : Base, IPublisher
    {
        public ContentPagePublisher(IDocumentSession session) : base(session) { }

        public void Publish(string id, string action)
        {
            
        }

        public void Publish(string[] ids, string action)
        {
            throw new System.NotImplementedException();
        }
    }
}