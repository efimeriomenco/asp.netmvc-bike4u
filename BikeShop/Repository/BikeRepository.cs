using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly AppDBContent appDBContent;
        public BikeRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Bike> AllBikes => appDBContent.Bike.Include(c => c.Category).ToList();
        public IEnumerable<Bike> FavBikes => appDBContent.Bike.Where(p => p.favorite).Include(c => c.Category).ToList();
        public Bike getBikeId(int bikeId) => appDBContent.Bike.FirstOrDefault(p => p.id == bikeId);
        public IEnumerable<Bike> SearchBikes(string searchText)
        {
            //return from bike in appDBContent.Bike
            //    where bike.searchText.Contains(searchText)
            //    select bike;

            //return appDBContent
            //    .Bike
            //    .SearchAllFullText(searchText);
            return appDBContent
                .Bike
                .Where(x => x.name.Contains(searchText))
                .Include(x => x.Category)
                .ToList();
        }

        public Task<Bike> GetById(int id)
        {
           return appDBContent.Bike.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
