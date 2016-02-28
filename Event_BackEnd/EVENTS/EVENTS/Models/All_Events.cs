using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTS.Models
{
    public class All_Events
    {
        public int ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public string LOGO_NAME { get; set; }
        public string START_DATE { get; set; }
        public string CREATED_DATE { get; set; }
        public string TITLE { get; set; }
    }
}