using Contoso.Events.Data;
using Contoso.Events.Models;
using System.Data.Entity;
using System.Linq;

namespace Contoso.Events.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(string eventKey)
        {
            using (EventsContext context = new EventsContext())
            {
                this.Event = context.Events
                    .Include(e => e.Registrants)
                    .Include(e => e.Location)
                    .SingleOrDefault(e => e.EventKey == eventKey);
            }
        }

        public Event Event { get; set; }
    }
}