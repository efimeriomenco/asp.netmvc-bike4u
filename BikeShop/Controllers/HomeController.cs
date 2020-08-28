using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BikeShop.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeShop.Models;
using BikeShop.ViewModel;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContacts _allContactses;

        public HomeController(ILogger<HomeController> logger, IContacts allcontacts)
        {
            _logger = logger;
            _allContactses = allcontacts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public IActionResult Contacts()
        {
            var model = new ContactsViewModel
            {
                AllContactses = _allContactses.AllContacts.ToList(),
                Form = new FeedbackViewModel {selectList = new SelectList(new[] {"Moldova", "Romania"})}
            };
            return View(model);
          //  string[] countries = {"Moldova",}
        }
        
        [HttpPost]
        public IActionResult Contacts(ContactsViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Contacts");
            }
            else
            {
                model.AllContactses = _allContactses.AllContacts.ToList();
                model.Form.selectList = new SelectList(new[] {"Moldova", "Romania"}, model.Form.selectedItem);
                return View("Contacts",model);
            }
        }
    }
}
