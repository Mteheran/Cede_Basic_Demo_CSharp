using Cede_Basic_Events.Data.Interfaces;
using Cede_Basic_Events.Enums;
using Cede_Basic_Events.Models;
using Cede_Basic_Events_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data
{
    public class EventDataDB : IEventData
    {
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            Connection con = new Connection();

            var datatable = con.GetData("SELECT * FROM event");

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                Event objevent = new Event();
                objevent.EventId = Guid.Parse(datatable.Rows[i]["EventId"].ToString());
                objevent.Name = datatable.Rows[i]["Name"].ToString();
                objevent.Description = datatable.Rows[i]["Description"].ToString();
                objevent.EventDate = DateTime.Parse(datatable.Rows[i]["EventDate"].ToString());
                objevent.IsPrivate = bool.Parse(datatable.Rows[i]["IsPrivate"].ToString());
                //objevent.Status =  Enum.Parse(typeof(EventStatus), (datatable.Rows[i]["IsDeleted"].ToString()));
                objevent.PersonalId = Guid.Parse(datatable.Rows[i]["PersonalId"].ToString());
                
                events.Add(objevent);

            }

            return events;
        }

        public bool UpdateEvent(Event objevent)
        {
            Connection con = new Connection();

            var privateSQl = objevent.Name == "Migue" ? 1 : 0;

            string query = $@"
                               UPDATE Event
                               SET Name= '{objevent.Name}'
                                   ,Description= '{objevent.Description}'
                                   ,IsPrivate= {privateSQl}
                                   ,PersonalId= '{objevent.PersonalId}' 
                                   ,EventDate = '{objevent.EventDate.ToString("MM-dd-yyyy")}'
                                WHERE EventId = '{objevent.EventId}'";

            return con.ExecuteQuery(query);
        }
    }
}
