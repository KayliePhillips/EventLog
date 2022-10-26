using Microsoft.AspNetCore.Mvc;

namespace EventLog.Controllers
{
    public class EventTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
