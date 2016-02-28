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
using EVENTS.Messages;

namespace EVENTS.Oracle_Connection
{
    public class Tokens_Connection
    {
        static string token_con_string = ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString;
        OracleConnection oraconn = new OracleConnection(token_con_string);
        public OracleCommand Db_Connect_Method(string method_name)
        {
            oraconn.Open();
            OracleCommand cmd = oraconn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", "TOKEN_PACKAGE", method_name);
            return cmd;

        }

        public string check_token(TOKEN token)
        {

            try
            {
                OracleCommand cmd = Db_Connect_Method("check_token");
                cmd.Parameters.AddWithValue("u_token",token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);

                cmd.ExecuteNonQuery();

                return retVal.Value.ToString();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            finally { oraconn.Close(); }
        }

        public string return_user_id_by_token(TOKEN token)
        {
            try
            {
                OracleCommand cmd = Db_Connect_Method("get_user_info_by_token");
                cmd.Parameters.AddWithValue("u_token", token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter("u_id", OracleType.Cursor);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);

                OracleDataAdapter user_info = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                user_info.Fill(dt);

                string s = Convert.ToString(dt.Rows[0]["ID"]);

                return s;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            finally { oraconn.Close(); }
        }

        public IEnumerable<USERS> get_user_info_by_token(TOKEN token)
        {
            // create list
            List<USERS> user_info_list = new List<USERS>();
            USERS user = new USERS();
            try
            {
                OracleCommand cmd = Db_Connect_Method("get_user_info_by_token");
                cmd.Parameters.AddWithValue("u_token", token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter();
                retVal.OracleType = OracleType.Cursor;
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                // create a data adapter to use with the data set
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                // create Data table
                DataTable dt = new DataTable();
                // fill the data table
                da.Fill(dt);
                // add the rows of datatable to list
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    user.ID = int.Parse(dt.Rows[i][0].ToString());
                    user.USERNAME = dt.Rows[i]["USERNAME"].ToString();
                    user.PASSWORD = dt.Rows[i]["PASSWORD"].ToString();
                    user.NAME = dt.Rows[i]["PASSWORD"].ToString();
                    user.NAME = Convert.ToString(dt.Rows[i]["NAME"]);
                    user.SURNAME = Convert.ToString(dt.Rows[i]["SURNAME"]);
                    user.EMAIL = Convert.ToString(dt.Rows[i]["EMAIL"]);
                    user.STATUS = Convert.ToByte(dt.Rows[i]["STATUS"]);
                    user.IMAGE = Convert.ToString(dt.Rows[i]["IMAGE"]);
                    user.BIRTHDAY = Convert.ToString(dt.Rows[i]["BIRTHDAY"]);
                    user.GENDER = Convert.ToString(dt.Rows[i]["GENDER"]);
                    user.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                    user.UPDATED_DATE = Convert.ToString(dt.Rows[i]["UPDATED_DATE"]);
                    user.DEACTIVATED_DATE = Convert.ToString(dt.Rows[i]["DEACTIVATED_DATE"]);
                    user.ADMIN = Convert.ToInt32(dt.Rows[i]["ADMIN"]);
                    int modify = -1;
                    bool check_modify = int.TryParse(dt.Rows[i]["MODIFIED_STATUS_BY"].ToString(), out modify);
                    user.MODIFIED_STATUS_BY = modify;
                    int update = -1;
                    bool check_update = int.TryParse(dt.Rows[i]["UPDATED_BY"].ToString(), out update);
                    user.UPDATED_BY = update;
                    int create = -1;
                    bool check_create = int.TryParse(dt.Rows[i]["CREATED_BY"].ToString(), out create);
                    user.UPDATED_BY = create;
                    user.MESSAGE = Messages.Messages.Succesfull_Get_User_Info;
                    user_info_list.Add(user);
                }
            }
            catch (Exception exception)
            {
                user.MESSAGE = exception.Message;
            }
            finally
            {
                oraconn.Close();
            }
            return user_info_list;
        }


        public USERS user_info_by_token(TOKEN token)
        {
            USERS user = new USERS();
            try
            {
                OracleCommand cmd = Db_Connect_Method("get_user_info_by_token");
                cmd.Parameters.AddWithValue("u_token", token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter();
                retVal.OracleType = OracleType.Cursor;
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                // create a data adapter to use with the data set
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                // create Data table
                DataTable dt = new DataTable();
                // fill the data table
                da.Fill(dt);
                // add the rows of datatable to list
                int i = 0;

                user.ID = int.Parse(dt.Rows[i][0].ToString());
                user.USERNAME = dt.Rows[i]["USERNAME"].ToString();
                user.PASSWORD = dt.Rows[i]["PASSWORD"].ToString();
                user.NAME = dt.Rows[i]["PASSWORD"].ToString();
                user.NAME = Convert.ToString(dt.Rows[i]["NAME"]);
                user.SURNAME = Convert.ToString(dt.Rows[i]["SURNAME"]);
                user.EMAIL = Convert.ToString(dt.Rows[i]["EMAIL"]);
                user.STATUS = Convert.ToByte(dt.Rows[i]["STATUS"]);
                user.IMAGE = Convert.ToString(dt.Rows[i]["IMAGE"]);
                user.BIRTHDAY = Convert.ToString(dt.Rows[i]["BIRTHDAY"]);
                user.GENDER = Convert.ToString(dt.Rows[i]["GENDER"]);
                user.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                user.UPDATED_DATE = Convert.ToString(dt.Rows[i]["UPDATED_DATE"]);
                user.DEACTIVATED_DATE = Convert.ToString(dt.Rows[i]["DEACTIVATED_DATE"]);
                user.ADMIN = Convert.ToInt32(dt.Rows[i]["ADMIN"]);
                int modify = -1;
                bool check_modify = int.TryParse(dt.Rows[i]["MODIFIED_STATUS_BY"].ToString(), out modify);
                user.MODIFIED_STATUS_BY = modify;
                int update = -1;
                bool check_update = int.TryParse(dt.Rows[i]["UPDATED_BY"].ToString(), out update);
                user.UPDATED_BY = update;
                int create = -1;
                bool check_create = int.TryParse(dt.Rows[i]["CREATED_BY"].ToString(), out create);
                user.UPDATED_BY = create;
                user.MESSAGE = Messages.Messages.Succesfull_Get_User_Info;
                return user;
            }
            catch (Exception ex)
            { return user; }
            finally
            {
                oraconn.Close();
                
            }
            
        }

    }
}