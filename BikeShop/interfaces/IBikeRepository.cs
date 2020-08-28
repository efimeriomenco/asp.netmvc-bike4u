using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.Models;

namespace BikeShop.interfaces
{
    public interface IBikeRepository
    {
        IEnumerable<Bike> AllBikes { get; }
        IEnumerable<Bike> FavBikes { get;}
        Bike getBikeId(int bikeId);

        IEnumerable<Bike> SearchBikes(string searchText);

        Task<Bike> GetById(int id);
    }
}
