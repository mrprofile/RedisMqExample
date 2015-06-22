using System;
using Funq;
using Raven.Client;
using Raven.Client.Document;
using RedisMqExample.Publisher;
using ServiceStack.Messaging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.Redis;
using ServiceStack.Redis.Messaging;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace RedisMqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new ServerAppHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1400/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadLine(); //Block the server from exiting (i.e. if running inside Console App)
        }

        public class ServerAppHost : AppHostHttpListenerBase
        {
            public ServerAppHost() : base("Test Server", typeof(IndexerService).Assembly) { }

            public override void Configure(Container container)
            {
                OrmLiteConfig.DialectProvider = SqlServerOrmLiteDialectProvider.Instance;

                container.Register<IRedisClientsManager>(new PooledRedisClientManager("localhost:6800"));
                container.Register(c => c.Resolve<IRedisClientsManager>().GetCacheClient());

                container.Register(ctx => new DocumentStore { Url = "http://10.128.8.160:9000", DefaultDatabase = "esqtv" }.Initialize()).ReusedWithin(ReuseScope.Container);
                container.Register(c => c.Resolve<IDocumentStore>().OpenSession()).ReusedWithin(ReuseScope.None);
                container.Register(ctx => new PublisherContext(ctx.Resolve<IDocumentSession>())).ReusedWithin(ReuseScope.None); ;
                
                Routes
                    .Add<IndexerRequest>("/indexers", "POST,GET")
                    .Add<IndexerMessage>("/indexers/message", "POST,GET")
                    .Add<IndexerRequestBulk>("/indexers/bulk", "POST,GET");

                //Register MQ Service
                var mqService = new RedisMqServer(container.Resolve<IRedisClientsManager>());
                container.Register<IMessageService>(mqService);
                container.Register(mqService.MessageFactory);

                mqService.RegisterHandler<IndexerMessage>(ServiceController.ExecuteMessage, (message, exception) => Console.WriteLine("Got Exception from " + message.GetBody().Id + "\n" + exception.Message));
                mqService.RegisterHandler<IndexerRequest>(ServiceController.ExecuteMessage, (message, exception) => Console.WriteLine("Got Exception from " + message.GetBody().Id + "\n" + exception.Message), 5);
                mqService.RegisterHandler<IndexerRequestBulk>(ServiceController.ExecuteMessage, (message, exception) => Console.WriteLine("Got Exception from " + message.GetBody().Action + "\n" + exception.Message), 5);

                mqService.Start();

                RequestFilters.Add((httpReq, httpRes, requestDto) =>
                {
                    var documentSession = Container.Resolve<IDocumentStore>().OpenSession();
                    Container.Register(documentSession);
                });

                ResponseFilters.Add((httpReq, httpRes, requestDto) =>
                {
                    using (var documentSession = Container.Resolve<IDocumentSession>())
                    {
                        if (documentSession == null)
                            return;

                        if (httpRes.StatusCode >= 400 && httpRes.StatusCode < 600)
                            return;

                        documentSession.SaveChanges();
                    }
                });
            }
        }
    }
}


