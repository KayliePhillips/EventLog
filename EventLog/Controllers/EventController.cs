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

        public EventController(IEventRepository repo)
        {
            _repo = repo;
        }
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
            updateEvent = _repo.AssignEventProperties(updateEvent);
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
        public IActionResult DeleteEvent(Event eventToDelete)
        {
            _repo.DeleteEvent(eventToDelete);
            return RedirectToAction("Index");
        }
        public IActionResult Index(string sortOrder, string searchString)
        {

            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["EventNameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "eventName_desc" : "eventName";
            ViewData["AttendeeSortParam"] = String.IsNullOrEmpty(sortOrder) ? "attendee_desc" : "attendee";
            ViewData["EventTypeSortParam"] = String.IsNullOrEmpty(sortOrder) ? "eventType_desc" : "eventType";
            ViewData["SpecialAttributeSortParam"] = String.IsNullOrEmpty(sortOrder) ? "specialAttribute_desc" : "specialAttribute";
            ViewData["AddressSortParam"] = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "address";
            _ = ViewData["CurrentFilter"] == searchString;

            var events = _repo.GetAllEvents();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(x => x.EventName.ToLower().Contains(searchString.ToLower()) || x.EventType.ToLower().Contains(searchString.ToLower()) ||
                                           x.SpecialAttribute.ToLower().Contains(searchString.ToLower()) || x.Attendees.ToLower().Contains(searchString.ToLower()) ||
                                           x.Date.ToLower().Contains(searchString.ToLower()) || x.Address.ToLower().Contains(searchString.ToLower()) ||
                                           x.Description.ToLower().Contains(searchString.ToLower()));

            }

            switch (sortOrder)
            {
                case "date_desc" : events = events.OrderByDescending(s => s.Date); break;
                case "eventName" : events = events.OrderBy(s => s.EventName); break;
                case "eventName_desc": events = events.OrderByDescending(s => s.EventName); break;
                case "attendee" : events=events.OrderBy(s => s.Attendees); break;
                case "attendee_desc" : events = events.OrderByDescending(s => s.Attendees); break;
                case "eventType" : events = events.OrderBy(s => s.EventType); break;
                case "eventType_desc" : events = events.OrderByDescending(s => s.EventType); break;
                case "specialAttribute" : events = events.OrderBy(s => s.Attendees); break;
                case "specialAtribute_desc" : events = events.OrderByDescending(s => s.Attendees); break;
                case "address": events = events.OrderBy(s => s.Address); break;
                case "address_desc": events = events.OrderByDescending(s => s.Address); break;
                default: events = events.OrderBy(s => s.Date); break;
            };
            return View(events);

        }
    }
}
