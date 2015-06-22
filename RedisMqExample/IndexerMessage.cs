namespace RedisMqExample
{
    public class IndexerMessage
    {
        public string Id { get; set; }
        public string[] Ids { get; set; }
        public int ObjectKey { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}