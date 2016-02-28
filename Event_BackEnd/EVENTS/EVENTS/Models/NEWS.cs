using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.IO;
using System.Configuration;
using System.Data;
using EVENTS.Models;
using EVENTS.Oracle_Connection;
namespace EVENTS.Models
{
    public class NEWS
    {
        public int ID { get; set; }
        public string TEXT { get; set; }
        public string TITLE { get; set; }
        public string LOGO_NAME { get; set; }
        public string CREATED_DATE { get; set; }
    }
}