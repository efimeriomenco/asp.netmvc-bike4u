using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeShop.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string address { get; set; }
        public string number { get; set; }
    }
}
