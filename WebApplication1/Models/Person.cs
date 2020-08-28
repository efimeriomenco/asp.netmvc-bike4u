using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionBike { get; set; }
        public bool Available { get; set; }
        public bool Favorite { get; set; }
        public int PriceBike { get; set; }
        public string Img { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

    }
}
