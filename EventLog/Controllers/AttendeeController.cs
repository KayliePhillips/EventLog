using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLog.Models;
using EventLog.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EventLog.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public AttendeeController(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }
        public IActionResult Index()
        {
            var allAttendee = _attendeeRepository.GetAllAttendees();
            return View(allAttendee);
        }
        public IActionResult InsertAttendee()
        {
            return View();
        }
        public IActionResult InsertNewAttendeeToDatabase(Attendee attendetoInsert)
        {
            _attendeeRepository.InsertAttendee(attendetoInsert);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateAttendee(int id)
        {
            var attendee = _attendeeRepository.GetAttendee(id);
            if (attendee == null)
            {
                return View("Attendee Not Found");
            }
            return View(attendee);
        }
        public IActionResult ViewAttendee(int id)
        {
            var attendee = _attendeeRepository.GetAttendee(id);
            return View (attendee);
        }
        public IActionResult UpdateAttendeeToDatabase(Attendee attendeeToUpdate)
        {
            _attendeeRepository.UpdateAttendee(attendeeToUpdate);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAttendee(Attendee attendeeToDelete)
        {
            _attendeeRepository.DeleteAttendee(attendeeToDelete);
            return RedirectToAction("Index");
        }

    }
}
