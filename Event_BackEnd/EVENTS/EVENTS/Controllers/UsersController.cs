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
    public class UsersController : ApiController
    {
        [HttpPost]
        [ActionName("login")]
        public FrontToken Login(USERS user)
        {
            return new Users_Connection().Login(user);
        }

        [HttpPost]
        [ActionName("logout")]
        public string logout(TOKEN token)
        {
            return new Users_Connection().Logout(token);
        }

        [HttpPost]
        [ActionName("check_admin")]
        public string Check_admin(TOKEN token)
        {
            return new Users_Connection().Check_Admin(token);
        }

        [HttpPost]
        [ActionName("get")]
        public IEnumerable<USERS> get_all_user()
        {
            return new Users_Connection().Get_all_users();
        }

        [HttpPost]
        [ActionName("deactivate")]
        public string deactivate_user(USERS user)
        {
            return new Users_Connection().Deactivating_user(user);
        }

        [HttpPost]
        [ActionName("activate")]
        public string activate_user(USERS user)
        {
            return new Users_Connection().Activating_user(user);
        }

        [HttpPost]
        [ActionName("change_password")]
        public string change_password(USERS user)
        {
            return new Users_Connection().Change_password(user);
        }

        [HttpPost]
        [ActionName("edit")]
        public string edit_user(USERS user)
        {
            return new Users_Connection().Edit_user(user);
        }

        [HttpPost]
        [ActionName("add")]
        public string add_user(USERS user)
        {
            return new Users_Connection().Add_user(user);
        }

        [HttpPost]
        [ActionName("delete")]
        public string delete_user(USERS user)
        {
            return new Users_Connection().Delete_user(user);
        }

    }
}
