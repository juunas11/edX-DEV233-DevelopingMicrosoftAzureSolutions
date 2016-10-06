using Contoso.Events.Data;
using Contoso.Events.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Contoso.Events.ViewModels
{
    public class EventsViewModel
    {
        public EventsViewModel()
        {
            using (EventsContext context = new EventsContext())
            {
                this.Events = context.Events
                    .Include(e => e.Registrants)
                    .OrderByDescending(e => e.StartTime)
                    .ToList();
            }
        }

        public IEnumerable<Event> Events { get; set; }
    }
}