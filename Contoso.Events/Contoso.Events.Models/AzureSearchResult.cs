using System.Collections.Generic;
using Newtonsoft.Json;

namespace Contoso.Events.Models
{
    public class AzureSearchResult<T>
    {
        [JsonProperty("value")]
        public IList<T> Items { get; set; }
    }
}
