using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeShop.Models
{
    public class WareHouse
    {
        
        public int Id { get; set; }
        public bool ProductAvailability { get; set; }
        public List<Bike> Bikes { get; set; }
    }
}
