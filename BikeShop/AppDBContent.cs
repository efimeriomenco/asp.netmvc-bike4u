using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.Models;
using BikeShop.Repository;
using Microsoft.EntityFrameworkCore;



namespace BikeShop
{
    public class AppDBContent : DbContext
    {
       
         public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
         
            
        }

         public DbSet<Bike> Bike { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<WareHouse> WareHouse { get; set; }

    }

   
}