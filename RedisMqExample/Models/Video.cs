using System;

namespace RedisMqExample.Models
{
    public class Video : DocumentBase
    {
        public int Video_Key { get; set; }

        public string VideoName { get; set; }

        public bool bActive { get; set; }

        public DateTime InsertDate { get; set; }

        public string description { get; set; }

        public int? ImageDB3_Key { get; set; }

        public DateTime DatePublish { get; set; }

        public int bShowOnSite { get; set; }

        public bool bAdult { get; set; }

        public int? Seconds { get; set; }

        public bool bExcludeFromMediaPlayer { get; set; }

        public int? Episode_Key { get; set; }

        public int? VirtualDirectory_Key { get; set; }

        public bool bPlayable { get; set; }

        public bool bExcludeFromVideoIndex { get; set; }

        public Guid ContentID { get; set; }

        public int DailyRequests { get; set; }

        public int WeeklyRequests { get; set; }

        public int MonthlyRequests { get; set; }

        public long AllTimeRequests { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string ShortDescription { get; set; }

        public string VideoProcessorFilename { get; set; }

        public string LinkBackText { get; set; }

        public string LinkBackUrl { get; set; }

        public bool bFullEpisode { get; set; }

        public bool? bIsEsquire { get; set; }

        public string EsqImageUrl { get; set; }

        public string EsqKeywords { get; set; }

        public string EsqVideoKey { get; set; }

        public string HDVideoUrl { get; set; }

        public string SDVideoUrl { get; set; }

        public string VideoAkamaiFileName { get; set; }

        public string DeliverySnippet { get; set; }

        public string EncryptedKey { get; set; }

        public string InternalEncryptedKey { get; set; }

        public string ObjectId { get; set; }

    }
}
