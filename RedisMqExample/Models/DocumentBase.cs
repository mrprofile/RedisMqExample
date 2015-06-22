using ServiceStack.DataAnnotations;

namespace RedisMqExample.Models
{
    public abstract class DocumentBase
    {
        [Ignore]
        public string Id { get; set; }
    }
}