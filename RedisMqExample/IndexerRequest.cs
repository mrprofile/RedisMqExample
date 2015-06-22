namespace RedisMqExample
{
    public class IndexerRequest
    {
        public string Id { get; set; }
        public int ObjectKey { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}