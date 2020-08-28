using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Migrations;
using BikeShop.Models;
using BikeShop.Repository;
using BikeShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Korzh.EasyQuery.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace BikeShop.Controllers
{

    public class BikeController : Controller
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBikeCategory _allCategories;
        private readonly AppDBContent _dbContent;


        public BikeController(IBikeRepository bikeRepository , IBikeCategory bikeCategory, IContacts contacts, AppDBContent dbContent)
        {
            _bikeRepository = bikeRepository;
            _allCategories = bikeCategory;
            _dbContent = dbContent;
        }
        [HttpGet]
        public ViewResult List(string search)

        {
            if (string.IsNullOrEmpty(search))
            {
                var obj = new BikesListViewModel {AllBikes = _bikeRepository.AllBikes, currentCategory = "Bikes"};
                return View(obj);
               
            }
            else
            {
                ViewBag.value = search;
                var bikes = _bikeRepository.SearchBikes(search);
                var obj = new BikesListViewModel { AllBikes = bikes, currentCategory = "Bikes" };
                return View(obj);
            }

        }

    }
}
    