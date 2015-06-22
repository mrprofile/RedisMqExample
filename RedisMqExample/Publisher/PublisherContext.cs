using System.Collections.Generic;
using Raven.Client;
using RedisMqExample.Publisher.Concrete;
using RedisMqExample.Publisher.Interface;

namespace RedisMqExample.Publisher
{
    public class PublisherContext
    {
        public IDocumentSession RavenDbSession { get; set; }
        private readonly Dictionary<string, IPublisher> _publishers = new Dictionary<string, IPublisher>();

        public PublisherContext(IDocumentSession ravenDbSession)
        {
            RavenDbSession = ravenDbSession;

            _publishers.Add("slider", new SliderPublisher(RavenDbSession));
            _publishers.Add("contentpage", new ContentPagePublisher(RavenDbSession));
            _publishers.Add("video", new VideoPublisher(RavenDbSession));
            _publishers.Add("blog", new BlogPublisher(RavenDbSession));
        }

        public void Publish(string itemType, string id, string action)
        {
            _publishers[itemType].Publish(id, action);
        }

        public void PublishBulk(string itemType, string[] ids, string action)
        {
            _publishers[itemType].Publish(ids, action);
        }
    }
}