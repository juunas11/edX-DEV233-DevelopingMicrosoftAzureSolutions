using Newtonsoft.Json;

namespace Contoso.Events.Models
{
    public class EventSearchResult
    {
        [JsonProperty("@search.score")]
        public double SearchScore { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        public string EventKey { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
