using System;
using System.Diagnostics;
using Raven.Client;
using RedisMqExample.Publisher;
using ServiceStack.Common;
using ServiceStack.Messaging;
using ServiceStack.ServiceInterface;

namespace RedisMqExample
{
    public class IndexerService : Service
    {
        public IDocumentSession RavenDbSession { get; set; }
        public PublisherContext PublisherContext { get; set; }
        public IMessageFactory MsgFactory { get; set; }

        public IndexerService(IDocumentSession ravenDbSession, PublisherContext publisherContext)
        {
            RavenDbSession = ravenDbSession;
            PublisherContext = publisherContext;
        }

        public object Any(IndexerMessage req)
        {
            var sw = Stopwatch.StartNew();

            if (!req.Ids.IsEmpty() & req.Ids.Length > 0)
            {
                var uniqueCallbackQ = "mq:c1" + ":" + Guid.NewGuid().ToString("N");
                using (var mqClient = MsgFactory.CreateMessageQueueClient())
                {
                    var clientMsg = new Message<IndexerRequestBulk>(new IndexerRequestBulk
                    {
                        Action = req.Action, 
                        Type = req.Type, 
                        Ids = req.Ids
                    })
                    {
                        ReplyTo = uniqueCallbackQ
                    };

                    mqClient.Publish(clientMsg);
                }
            }

            if (!req.Id.IsEmpty())
            {
                var uniqueCallbackQ = "mq:c1" + ":" + Guid.NewGuid().ToString("N");
                using (var mqClient = MsgFactory.CreateMessageQueueClient())
                {
                    var clientMsg =
                        new Message<IndexerRequest>(new IndexerRequest
                        {
                            Id = req.Id,
                            ObjectKey = req.ObjectKey,
                            Type = req.Type,
                            Action = req.Action
                        })
                        {
                            ReplyTo = uniqueCallbackQ
                        };
                    
                    mqClient.Publish(clientMsg);
                }
            }

            return new IndexerMessageResponse()
            {
                TimeTakenMs = sw.ElapsedMilliseconds,
            };
        }

        public object Any(IndexerRequest req)
        {
            PublisherContext.Publish(req.Type, req.Id, req.Action);
            
            return new IndexerResponse { Result = "Processing Job!, " + req.Type + " " + req.Id + " " + req.ObjectKey };
        }

        public object Any(IndexerRequestBulk req)
        {
            var sw = Stopwatch.StartNew();

            if (!req.Ids.IsEmpty())
                PublisherContext.PublishBulk(req.Type, req.Ids, req.Action);

            return new IndexerResponse { Result = "Processing Job! " + sw.ElapsedMilliseconds };
        }
    }
}