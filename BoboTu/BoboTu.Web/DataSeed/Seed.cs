using BoboTu.Data;
using BoboTu.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.DataSeed
{
    public class Seed
    {
        public static void SeedFacilities(BoboTuDbContext context)
        {
            if (!context.VenueFacilities.Any())
            {


                var facilties = new List<Facility>
                {
                     new Facility(){ Name = "Przewijak" },
                     new Facility(){ Name = "Kącik zabaw" },
                     new Facility(){ Name = "Plac zabaw" },
                     new Facility(){ Name = "Krzesełka dla dzieci" },
                     new Facility(){ Name = "Menu dla dzieci" },
                     new Facility(){ Name = "Opekun/ka dla dzieci" },

                };

                foreach (var facility in facilties)
                {
                    context.Facilities.Add(facility);
                }

                context.SaveChanges();




            }
        }
    }
}
