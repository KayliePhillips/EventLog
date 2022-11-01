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
        public IActionResult InsertSpecialAttribute()
        {
            return View();
        }
        public IActionResult InsertNewSpecialAttributeToDatabase(SpecialAttribute specialAttributeToInsert)
        {
            _specialAttributeRepository.InsertSpecialAttribute(specialAttributeToInsert);
            return RedirectToAction("Index");

        }
        public IActionResult UpdateSpecialAttribute(int id)
        {
            var specialAttribute = _specialAttributeRepository.GetSpecialAttribute(id);
            if(specialAttribute == null)
            {
                return View("Special Attribute Not Found");
            }
            return View(specialAttribute);
        }
        public IActionResult UpdateSpecialAttributeToDatabase(SpecialAttribute specialAttributeToUpdate)
        {
            _specialAttributeRepository.UpdateSpecialAttribute(specialAttributeToUpdate);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSpecialAttribute(SpecialAttribute specialAttributeToDelete)
        {
            _specialAttributeRepository.DeleteSpecialAttribute(specialAttributeToDelete);
            return RedirectToAction("Index");
        }
    }
}
