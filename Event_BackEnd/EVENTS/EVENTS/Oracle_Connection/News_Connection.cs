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
namespace EVENTS.Oracle_Connection
{
    public class News_Connection
    {
        static string news_con_string = ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString;
        OracleConnection orcl_con = new OracleConnection(news_con_string);

        public OracleCommand DB_Connect(string method_name)
        {
            orcl_con.Open();
            OracleCommand news_command = new OracleCommand("NEWS_PACKAGE." + method_name, orcl_con);
            news_command.CommandType = CommandType.StoredProcedure;
            return news_command;

        }

        // add news
        public string add_news(NEWS news)
        {

            try
            {
                OracleCommand cmd = DB_Connect("add_news");
                OracleParameter retVal = new OracleParameter();
                retVal.OracleType = OracleType.Number;
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.Parameters.AddWithValue("u_title", news.TITLE);
                cmd.Parameters.AddWithValue("u_text", news.TEXT);
                cmd.Parameters.AddWithValue("u_logoname", news.LOGO_NAME);

                cmd.ExecuteNonQuery();


                if (int.Parse(retVal.Value.ToString()) > 0)
                {
                    return "News was added successfully";
                }
                else
                    return "Adding news was unable";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { orcl_con.Close(); }
        }

        // get all news
        public IEnumerable<NEWS> get_all_news()
        {
            // create list
            List<NEWS> news_list = new List<NEWS>();

            // add return value to Oracle Command
            OracleCommand cmd = DB_Connect("get_all_news");
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
                NEWS item = new NEWS();

                item.ID = int.Parse(dt.Rows[i][0].ToString());
                item.TITLE = dt.Rows[i][1].ToString();
                item.TEXT = dt.Rows[i][2].ToString();
                item.LOGO_NAME = dt.Rows[i][3].ToString();
                item.CREATED_DATE = dt.Rows[i]["CREATED_DATE"].ToString();
                news_list.Add(item);
            }

            orcl_con.Close();
            return news_list;
        }

        // update news
        public string edit_news(NEWS news)
        {
            try
            {
                // add return value to Oracle Command
                OracleCommand cmd = DB_Connect("update_news");
                OracleParameter retVal = new OracleParameter();
                retVal.OracleType = OracleType.Number;
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.Parameters.AddWithValue("u_id", news.ID);
                cmd.Parameters.AddWithValue("u_title", news.TITLE);
                cmd.Parameters.AddWithValue("u_text", news.TEXT);
                cmd.Parameters.AddWithValue("u_logoname", news.LOGO_NAME);

                // execute query
                cmd.ExecuteNonQuery();

                // compare retVal
                if (int.Parse(retVal.Value.ToString()) > 0)
                    return "News was updated successfully";
                else
                    return "Unable to update news";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { orcl_con.Close(); }

        }

        // delete news
        public string delete_news(NEWS news)
        {
            try
            {
                // add return value to Oracle Command
                OracleCommand cmd = DB_Connect("delete_news");
                OracleParameter retVal = new OracleParameter();
                retVal.OracleType = OracleType.Number;
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.Parameters.AddWithValue("u_id", news.ID);

                // execute query
                cmd.ExecuteNonQuery();

                // compare retVal
                if (int.Parse(retVal.Value.ToString()) > 0)
                    return "News was deleted successfully";
                else
                    return "Unable to delete news";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { orcl_con.Close(); }

        }
    }
}