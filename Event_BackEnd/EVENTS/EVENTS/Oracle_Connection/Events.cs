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
    public class Events
    {
        static string users_con_string = ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString;
        OracleConnection orcl_con = new OracleConnection(users_con_string);

        public OracleCommand DB_Connect(string method_name)
        {
            orcl_con.Open();
            OracleCommand events_commands = orcl_con.CreateCommand();
            events_commands.CommandText = string.Format("{0}.{1}", "Event_PACKAGE", method_name);
            events_commands.CommandType = CommandType.StoredProcedure;
            return events_commands;
        }

        #region add event
        // Add Sport event
        public string Add_event_sport(SPORT sport)
        {
            try
            {
                OracleCommand sport_command = DB_Connect("save_event_sport");
                sport_command.Parameters.AddWithValue("e_category_id", Convert.ToInt32(sport.CATEGORY_ID));
                sport_command.Parameters.AddWithValue("e_title", sport.TITLE);
                sport_command.Parameters.AddWithValue("e_adress", sport.ADDRESS);
                sport_command.Parameters.AddWithValue("e_description", sport.DESCRIPTION);
                sport_command.Parameters.AddWithValue("e_price", sport.PRICE);
                sport_command.Parameters.AddWithValue("e_price_cost",sport.PRICE_COST);
                sport_command.Parameters.AddWithValue("e_longitude", Convert.ToDouble( sport.LONGITUDE));
                sport_command.Parameters.AddWithValue("e_latitude", Convert.ToDouble( sport.LATITUDE));
                sport_command.Parameters.AddWithValue("e_start_date", sport.START_DATE.ToString());
                sport_command.Parameters.AddWithValue("e_end_date", sport.END_DATE.ToString());
                sport_command.Parameters.AddWithValue("e_kind_id", Convert.ToInt32(sport.KIND_ID));
                sport_command.Parameters.AddWithValue("e_logoname", sport.LOGO_NAME);
                sport_command.Parameters.AddWithValue("e_created_by", Convert.ToInt32(sport.CREATED_BY));
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                sport_command.Parameters.Add(retVal);

                sport_command.ExecuteNonQuery();

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
        //Add Seminar event
        public string Add_event_seminar(SEMINAR seminar)
        {
            try
            {
                OracleCommand seminar_command = DB_Connect("save_event_seminar");
                seminar_command.Parameters.AddWithValue("e_category_id", seminar.CATEGORY_ID);
                seminar_command.Parameters.AddWithValue("e_author", seminar.AUTHOR);
                seminar_command.Parameters.AddWithValue("e_subject", seminar.SUBJECT);
                seminar_command.Parameters.AddWithValue("e_title", seminar.TITLE);
                seminar_command.Parameters.AddWithValue("e_adress", seminar.ADDRESS);
                seminar_command.Parameters.AddWithValue("e_description", seminar.DESCRIPTION);
                seminar_command.Parameters.AddWithValue("e_price", seminar.PRICE);
                seminar_command.Parameters.AddWithValue("e_price_cost", seminar.PRICE_COST);
                seminar_command.Parameters.AddWithValue("e_logoname", seminar.LOGO_NAME);
                seminar_command.Parameters.AddWithValue("e_longitude", seminar.LONGITUDE);
                seminar_command.Parameters.AddWithValue("e_latitude", seminar.LATITUDE);
                seminar_command.Parameters.AddWithValue("e_start_date", seminar.START_DATE);
                seminar_command.Parameters.AddWithValue("e_end_date", seminar.END_DATE);
                seminar_command.Parameters.AddWithValue("e_kind_id", seminar.KIND_ID);
                seminar_command.Parameters.AddWithValue("e_created_by", seminar.CREATED_BY);
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                seminar_command.Parameters.Add(retVal);

                seminar_command.ExecuteNonQuery();


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
        //Add presentation Event
        public string Add_event_presentation(PRESENTATION presentation)
        {
            try
            {
                OracleCommand presentation_command = DB_Connect("save_event_presentation");
                presentation_command.Parameters.AddWithValue("e_category_id", presentation.CATEGORY_ID);
                presentation_command.Parameters.AddWithValue("e_author", presentation.AUTHOR);
                presentation_command.Parameters.AddWithValue("e_title", presentation.TITLE);
                presentation_command.Parameters.AddWithValue("e_adress", presentation.ADDRESS);
                presentation_command.Parameters.AddWithValue("e_description", presentation.DESCRIPTION);
                presentation_command.Parameters.AddWithValue("e_price", presentation.PRICE);
                presentation_command.Parameters.AddWithValue("e_price_cost", presentation.PRICE_COST);
                presentation_command.Parameters.AddWithValue("e_logoname", presentation.LOGO_NAME);
                presentation_command.Parameters.AddWithValue("e_longitude", presentation.LONGITUDE);
                presentation_command.Parameters.AddWithValue("e_latitude", presentation.LATITUDE);
                presentation_command.Parameters.AddWithValue("e_start_date", presentation.START_DATE);
                presentation_command.Parameters.AddWithValue("e_end_date", presentation.END_DATE);
                presentation_command.Parameters.AddWithValue("e_kind_id", presentation.KIND_ID);
                presentation_command.Parameters.AddWithValue("e_created_by", presentation.CREATED_BY);
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                presentation_command.Parameters.Add(retVal);

                presentation_command.ExecuteNonQuery();

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
        //add theatre event
        public string Add_event_theatre(THEATRE theatre)
        {
            try
            {
                OracleCommand theatre_command = DB_Connect("save_event_theatre");
                theatre_command.Parameters.AddWithValue("e_category_id", theatre.CATEGORY_ID);
                theatre_command.Parameters.AddWithValue("e_senarist", theatre.SENARIST);
                theatre_command.Parameters.AddWithValue("e_producer", theatre.PRODUCER);
                theatre_command.Parameters.AddWithValue("e_organizer", theatre.ORGANIZER);
                theatre_command.Parameters.AddWithValue("e_title", theatre.TITLE);
                theatre_command.Parameters.AddWithValue("e_adress", theatre.ADDRESS);
                theatre_command.Parameters.AddWithValue("e_description", theatre.DESCRIPTION);
                theatre_command.Parameters.AddWithValue("e_price", theatre.PRICE);
                theatre_command.Parameters.AddWithValue("e_price_cost", theatre.PRICE_COST);
                theatre_command.Parameters.AddWithValue("e_logoname", theatre.LOGO_NAME);
                theatre_command.Parameters.AddWithValue("e_longitude", theatre.LONGITUDE);
                theatre_command.Parameters.AddWithValue("e_latitude", theatre.LATITUDE);
                theatre_command.Parameters.AddWithValue("e_start_date", theatre.START_DATE);
                theatre_command.Parameters.AddWithValue("e_end_date", theatre.END_DATE);
                theatre_command.Parameters.AddWithValue("e_kind_id", theatre.KIND_ID);
                theatre_command.Parameters.AddWithValue("e_created_by", theatre.CREATED_BY);
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                theatre_command.Parameters.Add(retVal);

                theatre_command.ExecuteNonQuery();


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
        //add tour event
        public string Add_event_tour(TOUR tour)
        {
            try
            {
                OracleCommand tour_command = DB_Connect("save_event_tour");
                tour_command.Parameters.AddWithValue("e_category_id", tour.CATEGORY_ID);
                tour_command.Parameters.AddWithValue("e_author", "ATL");
                tour_command.Parameters.AddWithValue("e_title", tour.TITLE);
                tour_command.Parameters.AddWithValue("e_adress", tour.ADDRESS);
                tour_command.Parameters.AddWithValue("e_description", tour.DESCRIPTION);
                tour_command.Parameters.AddWithValue("e_organizer", tour.ORGANIZER);
                tour_command.Parameters.AddWithValue("e_destination", tour.DESTINATION);
                tour_command.Parameters.AddWithValue("e_assembling_point", tour.ASSEMBLING_POINT);
                tour_command.Parameters.AddWithValue("e_transportation", tour.TRANSPORTATION);
                tour_command.Parameters.AddWithValue("e_price", tour.PRICE);
                tour_command.Parameters.AddWithValue("e_price_cost", tour.PRICE_COST);
                tour_command.Parameters.AddWithValue("e_logoname", tour.LOGO_NAME);
                tour_command.Parameters.AddWithValue("e_longitude", tour.LONGITUDE);
                tour_command.Parameters.AddWithValue("e_latitude", tour.LATITUDE);
                tour_command.Parameters.AddWithValue("e_start_date", tour.START_DATE);
                tour_command.Parameters.AddWithValue("e_end_date", tour.END_DATE);
                tour_command.Parameters.AddWithValue("e_kind_id", tour.KIND_ID);
                tour_command.Parameters.AddWithValue("e_created_by", tour.CREATED_BY);
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                tour_command.Parameters.Add(retVal);

                tour_command.ExecuteNonQuery();


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
        //add concert event
        public string Add_event_concert(CONCERT concert)
        {
            try
            {
                OracleCommand concert_command = DB_Connect("save_event_concert");
                concert_command.Parameters.AddWithValue("e_category_id", concert.CATEGORY_ID);
                concert_command.Parameters.AddWithValue("e_singer", concert.SINGER);
                concert_command.Parameters.AddWithValue("e_title", concert.TITLE);
                concert_command.Parameters.AddWithValue("e_adress", concert.ADDRESS);
                concert_command.Parameters.AddWithValue("e_description", concert.DESCRIPTION);
                concert_command.Parameters.AddWithValue("e_organizer", concert.ORGANIZER);
                concert_command.Parameters.AddWithValue("e_price", concert.PRICE);
                concert_command.Parameters.AddWithValue("e_price_cost", concert.PRICE_COST);
                concert_command.Parameters.AddWithValue("e_logoname", concert.LOGO_NAME);
                concert_command.Parameters.AddWithValue("e_longitude", concert.LONGITUDE);
                concert_command.Parameters.AddWithValue("e_latitude", concert.LATITUDE);
                concert_command.Parameters.AddWithValue("e_start_date", concert.START_DATE);
                concert_command.Parameters.AddWithValue("e_end_date", concert.END_DATE);
                concert_command.Parameters.AddWithValue("e_kind_id", concert.KIND_ID);
                concert_command.Parameters.AddWithValue("e_created_by", concert.CREATED_BY);
                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                concert_command.Parameters.Add(retVal);

                concert_command.ExecuteNonQuery();


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
        //add exhibition event
        public string Add_event_exhibition(EXHIBITION exhibition)
        {
            try
            {
                OracleCommand exhibition_command = DB_Connect("save_event_exhibition");
                exhibition_command.Parameters.AddWithValue("e_category_id", exhibition.CATEGORY_ID);
                exhibition_command.Parameters.AddWithValue("e_author", exhibition.AUTHOR);
                exhibition_command.Parameters.AddWithValue("e_title", exhibition.TITLE);
                exhibition_command.Parameters.AddWithValue("e_adress", exhibition.ADDRESS);
                exhibition_command.Parameters.AddWithValue("e_description", exhibition.DESCRIPTION);
                exhibition_command.Parameters.AddWithValue("e_price", exhibition.PRICE);
                exhibition_command.Parameters.AddWithValue("e_price_cost", exhibition.PRICE_COST);
                exhibition_command.Parameters.AddWithValue("e_logoname", exhibition.LOGO_NAME);
                exhibition_command.Parameters.AddWithValue("e_longitude", exhibition.LONGITUDE);
                exhibition_command.Parameters.AddWithValue("e_latitude", exhibition.LATITUDE);
                exhibition_command.Parameters.AddWithValue("e_start_date", exhibition.START_DATE);
                exhibition_command.Parameters.AddWithValue("e_end_date", exhibition.END_DATE);
                exhibition_command.Parameters.AddWithValue("e_kind_id", exhibition.KIND_ID);
                exhibition_command.Parameters.AddWithValue("e_created_by", exhibition.CREATED_BY);

                OracleParameter retVal = new OracleParameter("check_insert", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                exhibition_command.Parameters.Add(retVal);

                exhibition_command.ExecuteNonQuery();


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
        #endregion

        #region get events
        //get sport events
        public CoreModel get_sport_events(Page page)
        {
            OracleCommand get_sport_command = DB_Connect("get_all_events_sport");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_sport_command.Parameters.Add(retVal);
            get_sport_command.Parameters.Add(outPut);
            get_sport_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_sport_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_sport_command.Parameters["eventsCount"].Value);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get seminar events
        public CoreModel get_concert_events(Page page)
        {
            OracleCommand get_concert_command = DB_Connect("get_all_events_concert");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_concert_command.Parameters.Add(retVal);
            get_concert_command.Parameters.Add(outPut);
            get_concert_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_concert_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_concert_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get seminar events
        public CoreModel get_seminar_events(Page page)
        {
            OracleCommand get_seminar_command = DB_Connect("get_all_events_seminar");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_seminar_command.Parameters.Add(retVal);
            get_seminar_command.Parameters.Add(outPut);
            get_seminar_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_seminar_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_seminar_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
                
                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get exhibition events
        public CoreModel get_exhibition_events(Page page)
        {
            OracleCommand get_exhibition_command = DB_Connect("get_all_events_exhibition");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_exhibition_command.Parameters.Add(retVal);
            get_exhibition_command.Parameters.Add(outPut);
            get_exhibition_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_exhibition_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_exhibition_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get presentation events
        public CoreModel get_presentation_events(Page page)
        {
            OracleCommand get_presentation_command = DB_Connect("get_all_events_presentation");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_presentation_command.Parameters.Add(retVal);
            get_presentation_command.Parameters.Add(outPut);
            get_presentation_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_presentation_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_presentation_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get tour events
        public CoreModel get_tour_events(Page page)
        {
            OracleCommand get_tour_command = DB_Connect("get_all_events_tour");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            retVal.Direction = ParameterDirection.ReturnValue;
            outPut.Direction = ParameterDirection.Output;
            get_tour_command.Parameters.Add(outPut);
            get_tour_command.Parameters.Add(retVal);
            get_tour_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_tour_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_tour_command.Parameters["eventsCount"].Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //get theatre events
        public CoreModel get_theatre_events(Page page)
        {
            OracleCommand get_theatre_command = DB_Connect("get_all_events_theatre");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            retVal.Direction = ParameterDirection.ReturnValue;
            outPut.Direction = ParameterDirection.Output;
            get_theatre_command.Parameters.Add(retVal);
            get_theatre_command.Parameters.Add(outPut);
            get_theatre_command.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(get_theatre_command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_theatre_command.Parameters["eventsCount"].Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);

                list.Add(item);
                coremodel.events = list;
            }
            orcl_con.Close();
            return coremodel;
        }

        //get all events
        public CoreModel get_all_events(Page page)
        {
            OracleCommand cmd = DB_Connect("get_all_events");
            OracleParameter retVal = new OracleParameter();
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(outPut);
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("page", page.PAGE);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(cmd.Parameters["eventsCount"].Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
            coremodel.events = list;
            orcl_con.Close();
            return coremodel;
        }

        #endregion

        #region  update events
        //edit sport event
        public string Update_Sport(SPORT sport)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_sport");
                cmd.Parameters.AddWithValue("event_id", sport.ID);
                cmd.Parameters.AddWithValue("e_adress", sport.ADDRESS);
                cmd.Parameters.AddWithValue("e_title", sport.TITLE);
                cmd.Parameters.AddWithValue("e_description", sport.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_price", sport.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", sport.PRICE_COST);
                cmd.Parameters.AddWithValue("e_longitude", sport.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", sport.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", sport.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", sport.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", sport.KIND_ID);
                cmd.Parameters.AddWithValue("e_logoname", sport.LOGO_NAME);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit seminar event
        public string Update_Seminar(SEMINAR seminar)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_seminar");
                cmd.Parameters.AddWithValue("event_id", seminar.ID);
                cmd.Parameters.AddWithValue("e_author", seminar.AUTHOR);
                cmd.Parameters.AddWithValue("e_subject", seminar.SUBJECT);
                cmd.Parameters.AddWithValue("e_title", seminar.TITLE);
                cmd.Parameters.AddWithValue("e_adress", seminar.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", seminar.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_price", seminar.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", seminar.PRICE_COST);
                cmd.Parameters.AddWithValue("e_longitude", seminar.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", seminar.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", seminar.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", seminar.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", seminar.KIND_ID);
                cmd.Parameters.AddWithValue("e_logoname", seminar.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_updated_by", seminar.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit presentation event
        public string Update_Presentation(PRESENTATION presentation)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_presentation");
                cmd.Parameters.AddWithValue("event_id", presentation.ID);
                cmd.Parameters.AddWithValue("e_author", presentation.AUTHOR);
                cmd.Parameters.AddWithValue("e_title", presentation.TITLE);
                cmd.Parameters.AddWithValue("e_adress", presentation.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", presentation.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_price", presentation.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", presentation.PRICE_COST);
                cmd.Parameters.AddWithValue("e_logoname", presentation.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_longitude", presentation.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", presentation.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", presentation.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", presentation.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", presentation.KIND_ID);
                cmd.Parameters.AddWithValue("e_updated_by", presentation.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit theatre event
        public string Update_Theatre(THEATRE theatre)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_theatre");
                cmd.Parameters.AddWithValue("event_id", theatre.ID);
                cmd.Parameters.AddWithValue("e_senarist", theatre.SENARIST);
                cmd.Parameters.AddWithValue("e_producer", theatre.PRODUCER);
                cmd.Parameters.AddWithValue("e_title", theatre.TITLE);
                cmd.Parameters.AddWithValue("e_adress", theatre.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", theatre.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_organizer", theatre.ORGANIZER);
                cmd.Parameters.AddWithValue("e_price", theatre.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", theatre.PRICE_COST);
                cmd.Parameters.AddWithValue("e_logoname", theatre.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_longitude", theatre.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", theatre.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", theatre.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", theatre.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", theatre.KIND_ID);
                cmd.Parameters.AddWithValue("e_updated_by", theatre.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit tour event
        public string Update_Tour(TOUR tour)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_tour");
                cmd.Parameters.AddWithValue("event_id", tour.ID);
                cmd.Parameters.AddWithValue("e_author", tour.AUTHOR);
                cmd.Parameters.AddWithValue("e_title", tour.TITLE);
                cmd.Parameters.AddWithValue("e_adress", tour.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", tour.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_organizer", tour.ORGANIZER);
                cmd.Parameters.AddWithValue("e_destination", tour.DESTINATION);
                cmd.Parameters.AddWithValue("e_transportation", tour.TRANSPORTATION);
                cmd.Parameters.AddWithValue("e_assembling_point", tour.ASSEMBLING_POINT);
                cmd.Parameters.AddWithValue("e_price", tour.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", tour.PRICE_COST);
                cmd.Parameters.AddWithValue("e_logoname", tour.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_longitude", tour.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", tour.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", tour.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", tour.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", tour.KIND_ID);
                cmd.Parameters.AddWithValue("e_updated_by", tour.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit concert event
        public string Update_Concert(CONCERT concert)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_concert");
                cmd.Parameters.AddWithValue("event_id", concert.ID);
                cmd.Parameters.AddWithValue("e_singer", concert.SINGER);
                cmd.Parameters.AddWithValue("e_title", concert.TITLE);
                cmd.Parameters.AddWithValue("e_adress", concert.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", concert.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_organizer", concert.ORGANIZER);
                cmd.Parameters.AddWithValue("e_price", concert.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", concert.PRICE_COST);
                cmd.Parameters.AddWithValue("e_logoname", concert.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_longitude", concert.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", concert.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", concert.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", concert.END_DATE);
                cmd.Parameters.AddWithValue("e_kind_id", concert.KIND_ID);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        //edit exhibition event
        public string Update_Exhibition(EXHIBITION exhibition)
        {
            try
            {
                OracleCommand cmd = DB_Connect("update_event_exhibition");
                cmd.Parameters.AddWithValue("event_id", exhibition.ID);
                cmd.Parameters.AddWithValue("e_author", exhibition.AUTHOR);
                cmd.Parameters.AddWithValue("e_title", exhibition.TITLE);
                cmd.Parameters.AddWithValue("e_adress", exhibition.ADDRESS);
                cmd.Parameters.AddWithValue("e_description", exhibition.DESCRIPTION);
                cmd.Parameters.AddWithValue("e_price", exhibition.PRICE);
                cmd.Parameters.AddWithValue("e_price_cost", exhibition.PRICE_COST);
                cmd.Parameters.AddWithValue("e_logoname", exhibition.LOGO_NAME);
                cmd.Parameters.AddWithValue("e_longitude", exhibition.LONGITUDE);
                cmd.Parameters.AddWithValue("e_latitude", exhibition.LATITUDE);
                cmd.Parameters.AddWithValue("e_start_date", exhibition.START_DATE);
                cmd.Parameters.AddWithValue("e_end_date", exhibition.END_DATE);
                cmd.Parameters.Add("e_kind_id", exhibition.KIND_ID);
                cmd.Parameters.Add("e_updated_by", exhibition.UPDATED_BY);
                OracleParameter retVal = new OracleParameter("check_update", OracleType.Number);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);
                cmd.ExecuteNonQuery();
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
        #endregion

        #region get event for kind

        //sport category
        public CoreModel kind_sport_events(Page page)
        {
            OracleCommand get_sport_command = DB_Connect("kind_event_sport");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_sport_command.Parameters.Add(retVal);
            get_sport_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_sport_command.Parameters.AddWithValue("page", page.PAGE);
            get_sport_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_sport_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_sport_command.Parameters["eventsCount"].Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //concert category
        public CoreModel kind_concert_events(Page page)
        {
            OracleCommand get_concert_command = DB_Connect("kind_event_concert");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_concert_command.Parameters.Add(retVal);
            get_concert_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_concert_command.Parameters.AddWithValue("page", page.PAGE);
            get_concert_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_concert_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_concert_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //seminar category
        public CoreModel kind_seminar_events(Page page)
        {
            OracleCommand get_seminar_command = DB_Connect("kind_event_seminar");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_seminar_command.Parameters.Add(retVal);
            get_seminar_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_seminar_command.Parameters.AddWithValue("page", page.PAGE);
            get_seminar_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_seminar_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_seminar_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //exhibition category
        public CoreModel kind_exhibition_events(Page page)
        {
            OracleCommand get_exhibition_command = DB_Connect("kind_event_exhibition");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_exhibition_command.Parameters.Add(retVal);
            get_exhibition_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_exhibition_command.Parameters.AddWithValue("page", page.PAGE);
            get_exhibition_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_exhibition_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_exhibition_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);            
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);          
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //presentation category
        public CoreModel kind_presentation_events(Page page)
        {
            OracleCommand get_presentation_command = DB_Connect("kind_event_presentation");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_presentation_command.Parameters.Add(retVal);
            get_presentation_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_presentation_command.Parameters.AddWithValue("page", page.PAGE);
            get_presentation_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_presentation_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_presentation_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);              
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //tour category
        public CoreModel kind_tour_events(Page page)
        {
            OracleCommand get_tour_command = DB_Connect("kind_event_tour");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_tour_command.Parameters.Add(retVal);
            get_tour_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_tour_command.Parameters.AddWithValue("page", page.PAGE);
            get_tour_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_tour_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_tour_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);              
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]);         
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);       

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }
        //theatre category
        public CoreModel kind_theatre_events(Page page)
        {
            OracleCommand get_theatre_command = DB_Connect("kind_event_theatre");
            OracleParameter retVal = new OracleParameter("mycursor", OracleType.Cursor);
            OracleParameter outPut = new OracleParameter("eventsCount", OracleType.Number);
            outPut.Direction = ParameterDirection.Output;
            retVal.Direction = ParameterDirection.ReturnValue;
            get_theatre_command.Parameters.Add(retVal);
            get_theatre_command.Parameters.AddWithValue("k_id", page.KIND_ID);
            get_theatre_command.Parameters.AddWithValue("page", page.PAGE);
            get_theatre_command.Parameters.Add(outPut);
            OracleDataAdapter da = new OracleDataAdapter(get_theatre_command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CoreModel coremodel = new CoreModel();
            List<EventsModel> list = new List<EventsModel>();
            coremodel.events_count = Convert.ToInt32(get_theatre_command.Parameters["eventsCount"].Value);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EventsModel item = new EventsModel();
                item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
                item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);              
                item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
                item.CREATED_DATE = Convert.ToString(dt.Rows[i]["CREATED_DATE"]); 
                item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);

                list.Add(item);
            }
                coremodel.events = list;
                orcl_con.Close();
            return coremodel;
        }

        #endregion

        #region select_events
        // select sport event by id
        public SPORT select_sport_event(SPORT sport)
        {
            OracleCommand cmd = DB_Connect("select_event_sport");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", sport.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            SPORT item = new SPORT();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]); ;
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.SPORT_KIND = dt.Rows[i]["SPORT_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select seminar event by id
        public SEMINAR select_seminar_event(SEMINAR seminar)
        {
            OracleCommand cmd = DB_Connect("select_event_seminar");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", seminar.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            SEMINAR item = new SEMINAR();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.AUTHOR = dt.Rows[i]["AUTHOR"].ToString();
            item.TITLE = dt.Rows[i]["TITLE"].ToString();
            item.SUBJECT = dt.Rows[i]["SUBJECT"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            item.SEMINAR_KIND = dt.Rows[i]["SEMINAR_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select concert event by id
        public CONCERT select_concert_event(CONCERT concert)
        {
            OracleCommand cmd = DB_Connect("select_event_concert");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", concert.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            CONCERT item = new CONCERT();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.SINGER = dt.Rows[i]["SINGER"].ToString();
            item.ORGANIZER = dt.Rows[i]["ORGANIZER"].ToString();
            item.TITLE = dt.Rows[i]["TITLE"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            item.CONCERT_KIND = dt.Rows[i]["CONCERT_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select theatre event by id
        public THEATRE select_theatre_event(THEATRE theatre)
        {
            OracleCommand cmd = DB_Connect("select_event_theatre");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", theatre.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            THEATRE item = new THEATRE();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.SENARIST = dt.Rows[i]["SENARIST"].ToString();
            item.PRODUCER = dt.Rows[i]["PRODUCER"].ToString();
            item.ORGANIZER = dt.Rows[i]["ORGANIZER"].ToString();
            item.TITLE = Convert.ToString(dt.Rows[i]["TITLE"]);
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.THEATRE_KIND = dt.Rows[i]["THEATRE_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select tour event by id
        public TOUR select_tour_event(TOUR tour)
        {
            OracleCommand cmd = DB_Connect("select_event_tour");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", tour.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            TOUR item = new TOUR();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.AUTHOR = dt.Rows[i]["AUTHOR"].ToString();
            item.DESTINATION = dt.Rows[i]["DESTINATION"].ToString();
            item.TRANSPORTATION = dt.Rows[i]["TRANSPORTATION"].ToString();
            item.ASSEMBLING_POINT = dt.Rows[i]["ASSEMBLING_POINT"].ToString();
            item.ORGANIZER = dt.Rows[i]["ORGANIZER"].ToString();
            item.TITLE = dt.Rows[i]["TITLE"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            item.TOUR_KIND = dt.Rows[i]["TOUR_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select presentation event by id
        public PRESENTATION select_presentation_event(PRESENTATION presentation)
        {
            OracleCommand cmd = DB_Connect("select_event_presentation");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", presentation.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            PRESENTATION item = new PRESENTATION();

            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.AUTHOR = dt.Rows[i]["AUTHOR"].ToString();
            item.TITLE = dt.Rows[i]["TITLE"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            item.PRESENTATION_KIND = dt.Rows[i]["PRESENTATION_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            orcl_con.Close();
            return item;
        }

        // select exhibition event by id
        public EXHIBITION select_exhibition_event(EXHIBITION exhibition)
        {
            OracleCommand cmd = DB_Connect("select_event_exhibition");
            OracleParameter retVal = new OracleParameter();
            retVal.OracleType = OracleType.Cursor;
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retVal);
            cmd.Parameters.AddWithValue("e_id", exhibition.ID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = 0;
            EXHIBITION item = new EXHIBITION();
            item.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
            item.CATEGORY_ID = Convert.ToInt32(dt.Rows[i]["CATEGORY_ID"]);
            item.AUTHOR = dt.Rows[i]["AUTHOR"].ToString();
            item.TITLE = dt.Rows[i]["TITLE"].ToString();
            item.LONGITUDE = Convert.ToDouble(dt.Rows[i]["LONGITUDE"]);
            item.LATITUDE = Convert.ToDouble(dt.Rows[i]["LATITUDE"]);
            item.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
            item.PRICE = dt.Rows[i]["PRICE"].ToString();
            item.PRICE_COST = dt.Rows[i]["PRICE_COST"].ToString();
            item.ADDRESS = dt.Rows[i]["ADDRESS"].ToString();
            item.START_DATE = Convert.ToString(dt.Rows[i]["START_DATE"]);
            item.END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);
            item.LOGO_NAME = Convert.ToString(dt.Rows[i]["LOGO_NAME"]);
            item.KIND_ID = Convert.ToInt32(dt.Rows[i]["KIND_ID"]);
            item.NAME_CREATED_BY = dt.Rows[i]["CREATED_BY"].ToString();
            item.EXHIBITION_KIND = dt.Rows[i]["EXHIBITION_KIND"].ToString();
            item.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
            orcl_con.Close();
            return item;
        }

        #endregion

        #region delete_events

        public string  Delete_Sport(SPORT sport)
       {
         try
            {
                OracleCommand delete_command = DB_Connect("delete_sport");
                delete_command.Parameters.AddWithValue("u_id", sport.ID);
                OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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

        ///Delete Concert///////////
       public string Delete_Concert(CONCERT concert)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_concert");
               delete_command.Parameters.AddWithValue("u_id", concert.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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



       public string Delete_Seminar(SEMINAR seminar)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_seminar");
               delete_command.Parameters.AddWithValue("u_id", seminar.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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



       public string Delete_Tour(TOUR tour)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_tour");
               delete_command.Parameters.AddWithValue("u_id", tour.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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



       public string Delete_Theatre(THEATRE theatre)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_theatre");
               delete_command.Parameters.AddWithValue("u_id", theatre.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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


       public string Delete_Presentation(PRESENTATION presentation)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_presentation");
               delete_command.Parameters.AddWithValue("u_id", presentation.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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


       public string Delete_Exhibition(EXHIBITION exhibition)
       {
           try
           {
               OracleCommand delete_command = DB_Connect("delete_exhibition");
               delete_command.Parameters.AddWithValue("u_id", exhibition.ID);
               OracleParameter retVal = new OracleParameter("check_delete", OracleType.Number);
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

        #endregion
    }
}