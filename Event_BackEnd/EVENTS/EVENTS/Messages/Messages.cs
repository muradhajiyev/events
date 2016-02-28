using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTS.Messages
{
    public class Messages
    {
        public const string SuccesfullLoginIsAdmin= "1";
        public const string SuccesfullLoginNotAdmin = "0";
        public const string UnSuccesfullLogin = "-1";

        public const string SuccesfullLogout = "2";
        public const string UnSuccesfullLogout = "-2";

        public const string SuccesfullUpdate = "3";
        public const string UnSuccesfullUpdate = "-3";

        public const string SuccesfullInsert = "4";
        public const string UnSuccesfullInsert = "-4";

        public const string SuccesfullDelete = "5";
        public const string UnSuccesfullDelete = "-5";


        public const string SuccesfullActivation = "6";
        public const string UnSuccesfullActivation = "-6";

        public const string SuccesfullCheckToken = "7";
        public const string UnSuccesfullCheckToken = "-7";



        public const string SuccesfullPasswordChange = "8";
        public const string UnSuccesfullPasswordChange = "-8";

        public const string SuccesfullDeactivation = "9";
        public const string UnSuccesfullDeactivation = "-9";

        public const string SuccesfullAdmin = "10";
        public const string UnSuccesfullAdmin = "-10";

        public const string Succesfull_Get_User_Info = "11";
        public const string UnSuccesfull_Get_User_Info = "-11";
    }
}