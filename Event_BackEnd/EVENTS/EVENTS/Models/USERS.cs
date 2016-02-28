using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTS.Models
{
    public class USERS
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string Old_Password { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAIL { get; set; }
        public int STATUS { get; set; }
        public string IMAGE { get; set; }
        public string BIRTHDAY { get; set; }
        public string GENDER { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string DEACTIVATED_DATE { get; set; }
        public int ADMIN { get; set; }
        public int MODIFIED_STATUS_BY { get; set; }
        public int UPDATED_BY { get; set; }
        public int CREATED_BY { get; set; }
        public string MESSAGE { get; set; }
        public string MODIFIED_BY { get; set; }
        public string EDITED_BY { get; set; }
        public string ADDED_BY { get; set; }
        public string startPosition { get; set; }
        public string pageSize { get; set; }
    }
}