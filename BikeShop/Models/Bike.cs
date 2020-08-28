using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeShop.Models
{
    public class Bike
    {
        public int id {get;set;}
        public string name {get;set;}
        public string descriptionBike {get;set;}
        public string informationBike {get;set;}
        public bool available {get; set; }
        public bool favorite {get; set; }
        public int priceBike {get; set; }
        public string img {get;set;}
        public int categoryID {get; set; }
        public virtual Category Category {get;set;}

    }
}
