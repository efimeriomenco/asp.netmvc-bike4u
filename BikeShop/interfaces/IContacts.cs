using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.Models;

namespace BikeShop.interfaces
{
    public interface IContacts
    {
        IEnumerable<Contact> AllContacts { get; }
    }
}
