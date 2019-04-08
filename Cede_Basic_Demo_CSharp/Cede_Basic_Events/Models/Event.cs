using Cede_Basic_Events.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid PersonalId { get; set; }

        //encapsulamiento
        private string name { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDelete { get; set; }
        public EventStatus? Status { get; set; }
    }
}
