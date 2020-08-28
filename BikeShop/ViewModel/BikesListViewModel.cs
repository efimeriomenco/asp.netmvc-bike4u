using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.Models;

namespace BikeShop.ViewModel
{
    public class BikesListViewModel
    {
        public IEnumerable<Bike> AllBikes { get; set; }
        public string currentCategory { get; set; }
        public string Text { get; set; }
    }
}
