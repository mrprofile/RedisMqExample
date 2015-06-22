using ServiceStack.ServiceInterface.ServiceModel;

namespace RedisMqExample
{
    public class IndexerMessageResponse
    {
        public long TimeTakenMs { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}