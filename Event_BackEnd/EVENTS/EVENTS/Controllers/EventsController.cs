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
    public class EventsController : ApiController
    {

        #region update event
        [HttpPost]
        [ActionName("UpdateSport")]
        public string Update_Sport(SPORT sport)
        {
            return new Events().Update_Sport(sport);
        }
        
        [HttpPost]
        [ActionName("UpdateSeminar")]
        public string Update_Seminar(SEMINAR seminar)
        {
            return new Events().Update_Seminar(seminar);
        }


        [HttpPost]
        [ActionName("UpdatePresentation")]
        public string Update_Presentation(PRESENTATION presentation)
        {
            return new Events().Update_Presentation(presentation);
        }

        [HttpPost]
        [ActionName("UpdateTheatre")]
        public string Update_Theatre(THEATRE theatre)
        {
            return new Events().Update_Theatre(theatre);
        }

        [HttpPost]
        [ActionName("UpdateTour")]
        public string Update_Tour(TOUR tour)
        {
            return new Events().Update_Tour(tour);
        }

        [HttpPost]
        [ActionName("UpdateConcert")]
        public string Update_Concert(CONCERT concert)
        {
            return new Events().Update_Concert(concert);
        }


        [HttpPost]
        [ActionName("UpdateExhibition")]
        public string Update_Exhibition(EXHIBITION exhibition)
        {
            return new Events().Update_Exhibition(exhibition);
        }
#endregion

        #region add event controller
        [HttpPost]
        [ActionName("Add_event_sport")]
        public string Add_event_sport(SPORT sport)
        {

            return new Events().Add_event_sport(sport);
        }

        [HttpPost]
        [ActionName("Add_event_seminar")]
        public string Add_event_seminar(SEMINAR seminar)
        {
            return new Events().Add_event_seminar(seminar);
        }

        [HttpPost]
        [ActionName("Add_event_presentation")]
        public string Add_event_presentation(PRESENTATION presentation)
        {
            return new Events().Add_event_presentation(presentation);
        }

        [HttpPost]
        [ActionName("Add_event_theatre")]
        public string Add_event_theatre(THEATRE theatre)
        {
            return new Events().Add_event_theatre(theatre);
        }

        [HttpPost]
        [ActionName("Add_event_tour")]
        public string Add_event_tour(TOUR tour)
        {
            return new Events().Add_event_tour(tour);
        }

        [HttpPost]
        [ActionName("Add_event_concert")]
        public string Add_event_concert(CONCERT concert)
        {
            return new Events().Add_event_concert(concert);
        }

        [HttpPost]
        [ActionName("Add_event_exhibition")]
        public string Add_event_exhibition(EXHIBITION exhibition)
        {
            return new Events().Add_event_exhibition(exhibition);
        }
#endregion

        #region get controller

        [HttpPost]
        [ActionName("get_sport_events")]
        public CoreModel get_sport_events(Page page)
        {
            return new Events().get_sport_events(page);
        }

        [HttpPost]
        [ActionName("get_concert_events")]
        public CoreModel get_concert_events(Page page)
        {
            return new Events().get_concert_events(page);
        }

        [HttpPost]
        [ActionName("get_seminar_events")]
        public CoreModel get_seminar_events(Page page)
        {
            return new Events().get_seminar_events(page);
        }


        [HttpPost]
        [ActionName("get_exhibition_events")]
        public CoreModel get_exhibition_events(Page page)
        {
            return new Events().get_exhibition_events(page);
        }

        [HttpPost]
        [ActionName("get_presentation_events")]
        public CoreModel get_presentation_events(Page page)
        {
            return new Events().get_presentation_events(page);
        }

        [HttpPost]
        [ActionName("get_theatre_events")]
        public CoreModel get_theatre_events(Page page)
        {
            return new Events().get_theatre_events(page);
        }

        [HttpPost]
        [ActionName("get_tour_events")]
        public CoreModel get_tour_events(Page page)
        {
            return new Events().get_tour_events(page);
        }

        [HttpPost]
        [ActionName("get_all_events")]
        public CoreModel get_all_events(Page page)
        {

            return new Events().get_all_events(page);
        }

        #endregion

        #region event kind

        [HttpPost]
        [ActionName("kind_sport")]
        public CoreModel kind_sport_events(Page page)
        {
            return new Events().kind_sport_events(page);
        }

        [HttpPost]
        [ActionName("kind_concert")]
        public CoreModel kind_concert_events(Page page)
        {
            return new Events().kind_concert_events(page);
        }

        [HttpPost]
        [ActionName("kind_seminar")]
        public CoreModel kind_seminar_events(Page page)
        {
            return new Events().kind_seminar_events(page);
        }

        [HttpPost]
        [ActionName("kind_exhibition")]
        public CoreModel kind_exhibition_events(Page page)
        {
            return new Events().kind_exhibition_events(page);
        }

        [HttpPost]
        [ActionName("kind_presentation")]
        public CoreModel kind_presentation_events(Page page)
        {
            return new Events().kind_presentation_events(page);
        }

        [HttpPost]
        [ActionName("kind_tour")]
        public CoreModel kind_tour_events(Page page)
        {
            return new Events().kind_tour_events(page);
        }

        [HttpPost]
        [ActionName("kind_theatre")]
        public CoreModel kind_theatre_events(Page page)
        {
            return new Events().kind_theatre_events(page);
        }


        #endregion
        
        #region select event controller
        [HttpPost]
        [ActionName("select_sport_event")]
        public SPORT select_sport_event(SPORT sport)
        {
            return new Events().select_sport_event(sport);
        }

        [HttpPost]
        [ActionName("select_seminar_event")]
        public SEMINAR select_seminar_event(SEMINAR seminar)
        {
            return new Events().select_seminar_event(seminar);
        }

        [HttpPost]
        [ActionName("select_concert_event")]
        public CONCERT select_concert_event(CONCERT concert)
        {
            return new Events().select_concert_event(concert);
        }

        [HttpPost]
        [ActionName("select_theatre_event")]
        public THEATRE select_theatre_event(THEATRE theatre)
        {
            return new Events().select_theatre_event(theatre);
        }

        [HttpPost]
        [ActionName("select_tour_event")]
        public TOUR select_tour_event(TOUR tour)
        {
            return new Events().select_tour_event(tour);
        }

        [HttpPost]
        [ActionName("select_presentation_event")]
        public PRESENTATION select_presentation_event(PRESENTATION presentation)
        {
            return new Events().select_presentation_event(presentation);
        }

        [HttpPost]
        [ActionName("select_exhibition_event")]
        public EXHIBITION select_exhibition_event(EXHIBITION exhibition)
        {
            return new Events().select_exhibition_event(exhibition);
        }

        #endregion

        #region delete event
        [HttpPost]
        [ActionName("delete_sport")]
        public string delete_sport(SPORT sport)
        {
            return new Events().Delete_Sport(sport);
        }

        [HttpPost]
        [ActionName("delete_concert")]
        public string delete_concert(CONCERT concert)
        {
            return new Events().Delete_Concert(concert);
        }

        [HttpPost]
        [ActionName("delete_seminar")]
        public string delete_seminar(SEMINAR seminar)
        {
            return new Events().Delete_Seminar(seminar);
        }

        [HttpPost]
        [ActionName("delete_tour")]
        public string delete_tour(TOUR tour)
        {
            return new Events().Delete_Tour(tour);
        }

        [HttpPost]
        [ActionName("delete_theatre")]
        public string delete_theatre(THEATRE theatre)
        {
            return new Events().Delete_Theatre(theatre);
        }

        [HttpPost]
        [ActionName("delete_presentation")]
        public string delete_presentation(PRESENTATION presentation)
        {
            return new Events().Delete_Presentation(presentation);
        }

        [HttpPost]
        [ActionName("delete_exhibition")]
        public string delete_exhibition(EXHIBITION exhibition)
        {
            return new Events().Delete_Exhibition(exhibition);
        }

        #endregion
    }
}
