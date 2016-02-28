using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTS.Models
{
    public class PRESENTATION
    {
        public int ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public string AUTHOR { get; set; }
        public string TITLE { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public string PRICE { get; set; }
        public string PRICE_COST { get; set; }
        public string LOGO_NAME { get; set; }
        public double LONGITUDE { get; set; }
        public double LATITUDE { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string DELETED_DATE { get; set; }
        public int KIND_ID { get; set; }
        public int CREATED_BY { get; set; }
        public int STATUS { get; set; }
        public int UPDATED_BY { get; set; }
        public string NAME_CREATED_BY { get; set; }
        public string PRESENTATION_KIND { get; set; }
        public string CATEGORY { get; set; }
        public int PAGE { get; set; }
    }
}