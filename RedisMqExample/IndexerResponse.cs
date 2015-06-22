using ServiceStack.ServiceInterface.ServiceModel;

namespace RedisMqExample
{
    public class IndexerResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}