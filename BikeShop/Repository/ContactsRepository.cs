using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repository
{
    public class ContactsRepository : IContacts
    {
        private readonly AppDBContent appDBContent;

        public ContactsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Contact> AllContacts => appDBContent.Contacts;
    }
}
