using System.Collections.Generic;
using Contoso.Events.Models;

namespace Contoso.Events.ViewModels
{
    public class SearchViewModel
    {
        public string Term { get; set; }
        public IList<EventSearchResult> SearchResults { get; set; }
    }
}
