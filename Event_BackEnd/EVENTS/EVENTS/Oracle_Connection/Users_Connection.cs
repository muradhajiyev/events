using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.IO;
using System.Configuration;
using System.Data;
using EVENTS.Models;

namespace EVENTS.Oracle_Connection
{
    public class Users_Connection
    {
        static string users_con_string = ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString;
        OracleConnection orcl_con = new OracleConnection(users_con_string);
        static string token_front_check = "";
        public OracleCommand DB_Connect(string method_name)
        {
            orcl_con.Open();
            OracleCommand users_commands = new OracleCommand("USERS_PACKAGE." + method_name, orcl_con);
            users_commands.CommandType = CommandType.StoredProcedure;
            return users_commands;

        }
       // check login
        public FrontToken Login(USERS user)
        {
            FrontToken Loginde_Tokeni_ve_Messagi_Qaytariram = new FrontToken();
            try
            {
                string token = Guid.NewGuid().ToString();
                OracleCommand login_command = DB_Connect("check_login");
                login_command.Parameters.AddWithValue("u_username", user.USERNAME);
                login_command.Parameters.AddWithValue("u_password", user.PASSWORD);
                login_command.Parameters.AddWithValue("u_token", token);
                OracleParameter retVal = new OracleParameter("isadmin", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                login_command.Parameters.Add(retVal);
                token_front_check = token;
                login_command.ExecuteNonQuery();
                long result = Convert.ToInt64(retVal.Value.ToString());
                if (result == 0)
                {
                    Loginde_Tokeni_ve_Messagi_Qaytariram.Message = Messages.Messages.SuccesfullLoginNotAdmin;
                    Loginde_Tokeni_ve_Messagi_Qaytariram.token = token;
                }
                else if (result == 1)
                {
                    Loginde_Tokeni_ve_Messagi_Qaytariram.Message = Messages.Messages.SuccesfullLoginIsAdmin;
                    Loginde_Tokeni_ve_Messagi_Qaytariram.token = token;
                }
                    
                else
                    Loginde_Tokeni_ve_Messagi_Qaytariram.Message =  Messages.Messages.UnSuccesfullLogin;
            }
            catch (Exception ex)
            {
                Loginde_Tokeni_ve_Messagi_Qaytariram.Message=  ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
            return Loginde_Tokeni_ve_Messagi_Qaytariram;
        }
        //Log out
        public string Logout(TOKEN token)
        {
            try
            {
                OracleCommand logout_command = DB_Connect("Logout");
                logout_command.Parameters.AddWithValue("u_token", token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                logout_command.Parameters.Add(retVal);

                logout_command.ExecuteNonQuery();

                if (int.Parse(retVal.Value.ToString()) > 0)
                     return Messages.Messages.SuccesfullLogout;
                else
                    return Messages.Messages.UnSuccesfullLogout;
               
                    
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
            
        }


        public string Check_Admin(TOKEN token)
        {
            try
            {
                OracleCommand logout_command = DB_Connect("check_admin");
                logout_command.Parameters.AddWithValue("u_token", token.TOKEN_Values);
                OracleParameter retVal = new OracleParameter("isadmin", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                logout_command.Parameters.Add(retVal);

                logout_command.ExecuteNonQuery();
                return retVal.Value.ToString();


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }

        }

        //get all users
        public IEnumerable<USERS> Get_all_users()
        {
            OracleCommand get_users_command = DB_Connect("get_users");
            
            OracleParameter ret_val = new OracleParameter();
            ret_val.OracleType = OracleType.Cursor;
            ret_val.Direction = ParameterDirection.ReturnValue;
            get_users_command.Parameters.Add(ret_val);
            OracleDataAdapter adapter_users = new OracleDataAdapter(get_users_command);
            DataTable all_users =new DataTable();
            adapter_users.Fill(all_users);
            List<USERS> all_user_data=new List<USERS>();
            for (int i = 0; i < all_users.Rows.Count; i++)
            {
                USERS item = new USERS();
                item.ID = Convert.ToInt32(all_users.Rows[i]["ID"]);
                item.USERNAME = Convert.ToString(all_users.Rows[i]["USERNAME"]);
                item.PASSWORD = Convert.ToString(all_users.Rows[i]["PASSWORD"]);
                item.NAME = Convert.ToString(all_users.Rows[i]["NAME"]);
                item.SURNAME = Convert.ToString(all_users.Rows[i]["SURNAME"]);
                item.EMAIL = Convert.ToString(all_users.Rows[i]["EMAIL"]);
                item.STATUS = Convert.ToByte(all_users.Rows[i]["STATUS"]);
                item.IMAGE = Convert.ToString(all_users.Rows[i]["IMAGE"]);
                item.BIRTHDAY = Convert.ToString(all_users.Rows[i]["BIRTHDAY"]);
                item.GENDER = Convert.ToString(all_users.Rows[i]["GENDER"]);
                item.CREATED_DATE = Convert.ToString(all_users.Rows[i]["CREATED_DATE"]);
                item.UPDATED_DATE = Convert.ToString(all_users.Rows[i]["UPDATED_DATE"]);
                item.DEACTIVATED_DATE = Convert.ToString(all_users.Rows[i]["DEACTIVATED_DATE"]);
                item.ADMIN = Convert.ToInt32(all_users.Rows[i]["ADMIN"]);
                item.MODIFIED_BY = Convert.ToString(all_users.Rows[i]["modified_by"]);
                item.EDITED_BY = Convert.ToString(all_users.Rows[i]["edited_by"]);
                item.ADDED_BY = Convert.ToString(all_users.Rows[i]["added_by"]);

                all_user_data.Add(item);
            }

            return all_user_data;

        }
        //deactivate user
        public string Deactivating_user(USERS user)
        {
            try
            {
                OracleCommand deactive_command = DB_Connect("deactivate_user");
                deactive_command.Parameters.AddWithValue("u_id", user.ID);
                deactive_command.Parameters.AddWithValue("u_modified_status_by", user.MODIFIED_STATUS_BY);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                deactive_command.Parameters.Add(retVal);

                deactive_command.ExecuteNonQuery();

                if (int.Parse(retVal.Value.ToString()) > 0)
                    return "Deactivating successful";
                else
                    return "Please try deactivating again";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }     
        }
        //activate user
        public string Activating_user(USERS user)
        {
            try
            {
                OracleCommand active_command = DB_Connect("activate_user");
                active_command.Parameters.AddWithValue("u_id", user.ID);
                active_command.Parameters.AddWithValue("u_modified_status_by", user.MODIFIED_STATUS_BY);
               
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                active_command.Parameters.Add(retVal);

                active_command.ExecuteNonQuery();

                if (int.Parse(retVal.Value.ToString()) > 0)
                    return "Activating successful";
                else
                    return "Please try activating again";
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
        }
        //change password
        public string Change_password(USERS user)
        {
            try
            {
                OracleCommand change_password_command = DB_Connect("change_user_password");
                change_password_command.Parameters.AddWithValue("u_id", user.ID);
                change_password_command.Parameters.AddWithValue("u_new_password", user.PASSWORD);
                change_password_command.Parameters.AddWithValue("u_old_password", user.Old_Password);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                change_password_command.Parameters.Add(retVal);

                change_password_command.ExecuteNonQuery();

                if (int.Parse(retVal.Value.ToString()) > 0)
                    return "Password changed";
                else
                    return "Please check old password";
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
        }
        //update user
        public string Edit_user(USERS user)
        {
            try
            {
                OracleCommand update_command = DB_Connect("update_user");
                update_command.Parameters.AddWithValue("u_id", user.ID);
                update_command.Parameters.AddWithValue("u_username", user.USERNAME);
                update_command.Parameters.AddWithValue("u_password", user.PASSWORD);
                update_command.Parameters.AddWithValue("u_name", user.NAME);
                update_command.Parameters.AddWithValue("u_surname", user.SURNAME);
                update_command.Parameters.AddWithValue("u_email", user.EMAIL);
                update_command.Parameters.AddWithValue("u_birthday", user.BIRTHDAY);
                update_command.Parameters.AddWithValue("u_image", user.IMAGE);
                update_command.Parameters.AddWithValue("u_gender", user.GENDER);
                update_command.Parameters.AddWithValue("u_updated_by", user.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                update_command.Parameters.Add(retVal);

                update_command.ExecuteNonQuery();

                return retVal.Value.ToString();
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
        }
        //insert user
        public string Add_user(USERS user)
        {
            try
            {
                OracleCommand insert_command = DB_Connect("add_user");
                insert_command.Parameters.AddWithValue("u_username", user.USERNAME);
                insert_command.Parameters.AddWithValue("u_password", user.PASSWORD);
                insert_command.Parameters.AddWithValue("u_name", user.NAME);
                insert_command.Parameters.AddWithValue("u_surname", user.SURNAME);
                insert_command.Parameters.AddWithValue("u_email", user.EMAIL);
                //   insert_command.Parameters.AddWithValue("u_birthday", user.BIRTHDAY);
                // insert_command.Parameters.AddWithValue("u_image", user.IMAGE);
                insert_command.Parameters.AddWithValue("u_gender", user.GENDER);
                insert_command.Parameters.AddWithValue("u_created_by", user.CREATED_BY);
                insert_command.Parameters.AddWithValue("u_updated_by", user.UPDATED_BY);
                insert_command.Parameters.AddWithValue("u_modified_status_by", user.MODIFIED_STATUS_BY);
                OracleParameter retVal = new OracleParameter("u_id", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                insert_command.Parameters.Add(retVal);

                insert_command.ExecuteNonQuery();

                return retVal.Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
        }
        //delete user
        public string Delete_user(USERS user)
        {
            try
            {
                OracleCommand delete_command = DB_Connect("delete_user");
                delete_command.Parameters.AddWithValue("u_id", user.ID);
                OracleParameter retVal = new OracleParameter("r_code", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                delete_command.Parameters.Add(retVal);

                delete_command.ExecuteNonQuery();

                return retVal.Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                orcl_con.Close();
            }
        }
    }
}