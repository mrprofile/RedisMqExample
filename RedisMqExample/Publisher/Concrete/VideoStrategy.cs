using System;
using Raven.Client;
using RedisMqExample.Models;
using RedisMqExample.Publisher.Interface;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace RedisMqExample.Publisher.Concrete
{
    public class VideoPublisher : Base, IPublisher
    {
        public VideoPublisher(IDocumentSession session) : base(session) { }

        public void Publish(string id, string action)
        {
            if (action.ToLower() == "create")
            {
                using (var connection = OpenDbConnection())
                {
                    var video = connection.Single<Video>("Video_Key = {0}", id);
                    
                    if (video != null)
                    {
                        video.Id = "videos/" + video.Video_Key;

                        RavenSession.Store(video);
                        RavenSession.SaveChanges();
                        RavenSession.Dispose();
                    }
                }
            }
        }

        public void Publish(string[] ids, string action)
        {
            if (action.ToLower() == "create")
            {
                using (var connection = OpenDbConnection())
                {
                    var entities = connection.Select<Video>("Video_key IN ({0})".Fmt(String.Join(",", ids)));
                    const int numOfBatch = 128;

                    var batchCount = 0;

                    var session = RavenSession;

                    foreach (Video entity in entities)
                    {
                        batchCount++;
                        entity.Id = "videos/" + entity.Video_Key;
                        session.Store(entity);

                        if (batchCount%numOfBatch == 0)
                        {
                            batchCount = 0;
                            session.SaveChanges();
                            session.Dispose();
                            session = RavenSession;
                        }
                    }

                    session.SaveChanges();
                    session.Dispose();
                }
            }
        }
    }
}