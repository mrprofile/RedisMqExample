using System.Configuration;
using System.Data;
using Raven.Client;
using ServiceStack.OrmLite;

namespace RedisMqExample.Publisher.Concrete
{
    public abstract class Base
    {
        protected Base(IDocumentSession ravenDbSession)
        {
            RavenSession = ravenDbSession;
        }

        public IDocumentSession RavenSession { get; set; }
        public IDbConnection OpenDbConnection()
        {
            return ConfigurationManager.AppSettings["DbConnection"].OpenDbConnection();
        }
    }
}