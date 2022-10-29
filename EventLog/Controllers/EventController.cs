using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EventLog.Models;
using EventLog.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EventLog.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _repo;
        private readonly IEventTypeRepository _eventTypeRepo;

        public EventController(IEventRepository repo, IEventTypeRepository eventTypeRepo)
        {
            _repo = repo;
            _eventTypeRepo = eventTypeRepo;
        }

        //public IActionResult Index()
        //{
        //    var allEvents = _repo.GetAllEvents();
        //    return View(allEvents);
        //}

        public IActionResult ViewEvent(int id)
        {
            var viewEvent = _repo.GetEvent(id);
            return View(viewEvent);
        }
        
        public IActionResult InsertEvent()
        {
            var newEvent = _repo.AssignEventProperties();
            return View(newEvent);
        }
          
        public IActionResult InsertNewEventToDatabase(Event eventToInsert)
        {
            _repo.InsertEvent(eventToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult ViewUpdateEvent(int id)
        {
            var updateEvent = _repo.GetEvent(id);
            updateEvent = _repo.AssignEventProperties();
            if(updateEvent == null)
            {
                return View("Event Not Found");
            }
            return View(updateEvent);
        }

        public IActionResult UpdateEventToDatabase(Event eventToUpdate)
        {
            _repo.UpdateEvent(eventToUpdate);
            return RedirectToAction("ViewEvent", new { id = eventToUpdate.EventID });
        }

        //Delete event
        public IActionResult DeleteEvent(Event eventToDelete)
        {
            _repo.DeleteEvent(eventToDelete);
            return RedirectToAction("Index");
        }

        //Search -- needed to update the index method
        public IActionResult Index(string searchString)
        {

            //ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
           // ViewData["EventNameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
          //  ViewData["Attendees"] = sortOrder == "Attendees" ? "attendee_desc" : "";
            _=ViewData["CurrentFilter"] == searchString;

            var events = _repo.GetAllEvents();
            //var eventtype = _eventTypeRepo.GetAllEventTypes();

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(x => x.EventName.ToLower().Contains(searchString.ToLower()) || x.EventType.ToLower().Contains(searchString.ToLower()) ||
                                           x.SpecialAttribute.ToLower().Contains(searchString.ToLower()) || x.Attendees.ToLower().Contains(searchString.ToLower()) ||
                                           x.Date.ToLower().Contains(searchString.ToLower()) || x.Address.ToLower().Contains(searchString.ToLower()) ||
                                           x.Description.ToLower().Contains(searchString.ToLower()));

            }

            //switch (sortOrder)
            //{
            //    case "Date":
            //        events = events.OrderByDescending(s => s.Date);
            //        break;
            //    case "name_desc":
            //        events = events.OrderByDescending(s => s.EventType);
            //        break;
            //    case "Attendees":
            //        events = events.OrderByDescending(s => s.Attendees);
            //        break;
            //    default:
            //        events = events.OrderByDescending(s => s.EventType);
            //        break;
            //};



            return View(events);



        }


    }
}
