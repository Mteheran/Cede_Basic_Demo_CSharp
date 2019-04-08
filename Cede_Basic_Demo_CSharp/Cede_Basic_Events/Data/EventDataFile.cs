using Cede_Basic_Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data
{
    public class EventManagerFile
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Personal> Personals { get; set; } = new List<Personal>();

        public EventManagerFile()
        {
            Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Anderson", LastName = "Zapata", IsDeleted = false });
            Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Laura", LastName = "Arbelaez", IsDeleted = false });

            Events.Add(new Event() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"),  EventId = Guid.NewGuid(), Name = "Evento 1", Description = "Evento 1", EventDate = new DateTime(2019, 5, 5) });
            Events.Add(new Event() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), EventId = Guid.NewGuid(), Name = "Evento 2", Description = "Evento 2", EventDate = new DateTime(2019, 6, 10) });
            Events.Add(new Event() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), EventId = Guid.NewGuid(), Name = "Evento 3", Description = "Evento 3", EventDate = new DateTime(2019, 8, 15) });
        }

        public bool AddEvent(Event objevent)
        {
            Events.Add(objevent);
            return true;
        }

        public bool EditEvent(Guid EvenId, Event objevent)
        {
            int index = Events.IndexOf(Events.First(p => p.EventId == EvenId));
            Events[index] = objevent;
            return true;
        }

        public bool DeleteEvent(Guid EvenId)
        {
            var evenItem = Events.First(p => p.EventId == EvenId);
            Events.Remove(evenItem);
            return true;
        }

    }
}
