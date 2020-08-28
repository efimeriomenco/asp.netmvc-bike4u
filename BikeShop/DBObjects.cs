using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BikeShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
                

            if (!content.Bike.Any())
            {
                content.AddRange(
                     new Bike
                     {
                         name = "Vitus Nucleus VR",
                         descriptionBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                         informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                         available = true,
                         favorite = true,
                         priceBike = 500,
                         img = "/img/vitus.jpg",
                         Category = Categories["Mountain Bike"]
                     },
                        new Bike
                        {
                            name = "Voodoo Bizango",
                            descriptionBike = "There’s nothing magical about the meteoric success of the Bizango 29. Voodoo didn’t hex the competition, and you won’t find finger-bikes of its rivals with pins sticking out of the tyres if you visit Voodoo’s design HQ.",
                            informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            available = true,
                            favorite = true,
                            priceBike = 650,
                            img = "/img/bizango.jpg",
                            Category = Categories["Mountain Bike"]
                        },
                        new Bike
                        {
                            name = "Calibre Bossnut",
                            descriptionBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            available = false,
                            favorite = true,
                            priceBike = 1100,
                            img = "/img/calibre.jpg",
                            Category = Categories["Mountain Bike"]
                        },
                        new Bike
                        {
                            name = "VANMOOF S3",
                            descriptionBike = "The S3 is a very sturdily built thing that rides extremely well. You can get up to 20mph on the flat with minimal effort, and it irons out hills a treat. Hydraulic disk brakes bring it to a dead stop. ",
                            informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            available = true,
                            favorite = false,
                            priceBike = 1999,
                            img = "/img/s3.jpg",
                            Category = Categories["Electric Bike"]
                        },
                        new Bike
                        {
                            name = "ORBEA GAIN F40",
                            descriptionBike = "The Orbea Gain range has been designed to act as your daily whip, but also double-up as the weekend sportive machine, with its racy aluminium frame, carbon fork and powerful disc brakes making a solid case for racking up the miles during your downtime. ",
                            informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            available = false,
                            favorite = false,
                            priceBike = 1799,
                            img = "/img/f40.jpg",
                            Category = Categories["Electric Bike"]
                        }, new Bike
                        {
                            name = "AMPLER CURT",
                            descriptionBike = "Hand over the Ampler Curt to a friend and we will bet good money that they have no idea it is electrically assisted. The clever 48V LG Lithium-ion battery pack is neatly stashed into the down tube, while a powerful motor is stealthily tucked into the rear hub.",
                            informationBike = "If you’ve got £500 to spend on a new mountain bike the Vitus Nucleus VR is the only bike you need to consider.",
                            available = true,
                            favorite = true,
                            priceBike = 2890,
                            img = "/img/curt.jpg",
                            Category = Categories["Electric Bike"]
                        }
                    );
            }

            if(!content.Contacts.Any())
                content.Contacts.AddRange(
                    
            new Contact()
                        {
                            address = "Valea Crucii 42",
                             number = "079-07-03-02",
                        }
                    );
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category
                        {
                            categoryName = "Mountain Bike",
                            description = "Designed for off-road cycling"
                        },
                        new Category
                        {
                            categoryName = "Electric Bike",
                            description = "E-bike is a bicycle with an integrated electric motor which can be used for propulsion"

                        }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category elem in list)
                     category.Add(elem.categoryName,elem);
                }

                return category;

            }
        }

    
    }
}
