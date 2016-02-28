using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EVENTS.Models;
using EVENTS.Oracle_Connection;
namespace EVENTS.Controllers
{
    public class TokensController : ApiController
    {
        [HttpPost]
        [ActionName("check_token")]
        public string check_token(TOKEN token)
        {
            return new Tokens_Connection().check_token(token);
        }

        [HttpPost]
        [ActionName("return_id")]
        public string return_user_id_by_token(TOKEN token)
        {
            return new Tokens_Connection().return_user_id_by_token(token);
        }

        [HttpPost]
        [ActionName("get_user_info_by_token")]
        public IEnumerable<USERS> get_user_info_by_token(TOKEN token)
        {
            return new Tokens_Connection().get_user_info_by_token(token);
        }

        [HttpPost]
        [ActionName("user_info_by_token")]
        public USERS user_info_by_token(TOKEN token)
        {
            return new Tokens_Connection().user_info_by_token(token);
        }
    }
}
