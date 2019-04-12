using Cede_Basic_Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data.Interfaces
{
    public interface IEventData
    {
        List<Event> GetEvents();

        bool UpdateEvent(Event objevent);
    }
}
