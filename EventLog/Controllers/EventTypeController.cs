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
    }
}
