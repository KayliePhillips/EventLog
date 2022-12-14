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
    public class EventTypeController : Controller
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public EventTypeController(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        public IActionResult Index()
        {
            var allEventTypesList = _eventTypeRepository.GetAllEventTypes();

            return View(allEventTypesList);
        }
        public IActionResult InsertEventType()
        {
            return View();
        }
        public IActionResult InsertNewEventTypeToDatabase(EventType eventTypeToInsert)
        {
            _eventTypeRepository.InsertEventType(eventTypeToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEventType(int id)
        {
            var eventType = _eventTypeRepository.GetEventType(id);
            if(eventType == null)
            {
                return View("EventTypeNotFound");
            }
            return View(eventType);
        }
        public IActionResult UpdateEventTypeToDatabase(EventType eventTypeToUpdate)
        {
            _eventTypeRepository.UpdateEventType(eventTypeToUpdate);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEventType(EventType eventTypeToDelete)
        {
            _eventTypeRepository.DeleteEventType(eventTypeToDelete);
            return RedirectToAction("Index");
        }
    }
}
