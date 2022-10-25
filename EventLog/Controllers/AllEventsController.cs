using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EventLog.Controllers
{
    public class AllEventsController : Controller
    {
        private readonly IAllEventsRepository _repo;

        public AllEventsController(IAllEventsRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var allEvents = _repo.GetAllEvents();
            return View(allEvents);
        }
    }
}
