using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
