using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EventLog.Models;
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

        
        public IActionResult Index()
        {
            var allEvents = _repo.GetAllEvents();
            return View(allEvents);
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

    }
}
