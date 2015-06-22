using Raven.Client;
using RedisMqExample.Publisher.Interface;

namespace RedisMqExample.Publisher.Concrete
{
    public class SliderPublisher : Base, IPublisher
    {
        public SliderPublisher(IDocumentSession session) : base(session) { }

        public void Publish(string id, string action)
        {
            
        }

        public void Publish(string[] ids, string action)
        {
            throw new System.NotImplementedException();
        }
    }
}