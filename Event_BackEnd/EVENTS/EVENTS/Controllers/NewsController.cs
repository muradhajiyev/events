using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.OracleClient;
using System.IO;
using System.Configuration;
using System.Data;
using EVENTS.Models;
using EVENTS.Oracle_Connection;
namespace EVENTS.Controllers
{
    public class NewsController : ApiController
    {
        [HttpPost]
        [ActionName("add_news")]
        public string add_news(NEWS news)
        {
            return new News_Connection().add_news(news);
        }

        [HttpPost]
        [ActionName("get_all_news")]
        public IEnumerable<NEWS> gett_all_news()
        {
            return new News_Connection().get_all_news();
        }

        [HttpPost]
        [ActionName("edit_news")]
        public string update_news(NEWS news)
        {
            return new News_Connection().edit_news(news);
        }

        [HttpPost]
        [ActionName("delete_news")]
        public string delete_news(NEWS news)
        {
            return new News_Connection().delete_news(news);
        }


    }
}
