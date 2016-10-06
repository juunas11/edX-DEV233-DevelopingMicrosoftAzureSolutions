using Contoso.Events.Data;
using Contoso.Events.Models;
using System.Linq;
using System;

namespace Contoso.Events.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        { }

        public RegisterViewModel(string eventKey)
        {
            using (EventsContext context = new EventsContext())
            {
                this.Event = context.Events.SingleOrDefault(e => e.EventKey == eventKey);
            }
            this.Registration = new Registration();
        }

        public Event Event { get; set; }

        public Registration Registration { get; set; }

        public bool PersistRegistration()
        {
            using (EventsContext context = new EventsContext())
            {
                this.Event = context.Events.SingleOrDefault(e => e.EventKey == this.Event.EventKey);

                this.Registration.Timestamp = DateTime.Now;
                this.Registration.Event = this.Event;

                this.Registration = context.EventRegistrants.Add(this.Registration);

                context.SaveChanges();

                return true;
            }
        }
    }
}