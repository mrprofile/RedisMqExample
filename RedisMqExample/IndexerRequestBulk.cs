namespace RedisMqExample
{
    public class IndexerRequestBulk
    {
        public string[] Ids { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}