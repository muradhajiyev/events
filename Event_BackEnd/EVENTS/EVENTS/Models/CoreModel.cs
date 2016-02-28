using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTS.Models
{
    public class CoreModel
    {
        public int events_count { get; set; }
        public List<EventsModel> events { get; set; }
    }
}