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
    public class SpecialAttributeController : Controller
    {
        private readonly ISpecialAttributeRepository _specialAttributeRepository;

        public SpecialAttributeController(ISpecialAttributeRepository specialAttributeRepository)
        {
            _specialAttributeRepository = specialAttributeRepository;
        }

        public IActionResult Index()
        {
            var allSpecialAttributesList = _specialAttributeRepository.GetAllSpecialAttributes();
            return View(allSpecialAttributesList);
        }
    }
}
