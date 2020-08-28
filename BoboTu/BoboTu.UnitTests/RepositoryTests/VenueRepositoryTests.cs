using BoboTu.Data;
using BoboTu.Data.Models;
using BoboTu.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BoboTu.UnitTests.RepositoryTests
{
    public class VenueRepositoryTests
    {
        [Fact]
        public async Task AddNewVenueToDb()
        {
            var options = new DbContextOptionsBuilder<BoboTuDbContext>()
           .UseInMemoryDatabase($"BoboTuDatabaseForTesting{Guid.NewGuid()}")
           .Options;

            var venueData = System.IO.File.ReadAllText(@"VenueDataSeed/venueDataSeed.json");
            var venues = JsonConvert.DeserializeObject<List<Venue>>(venueData);
            int venueCount = 0;
            using (var context = new BoboTuDbContext(options))
            {
                context.Venues.AddRange(venues);
                context.SaveChanges();
                venueCount = context.Venues.Count();

            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);

                var venue = new Venue()
                {
                    AverageRating = 7.4,
                    City = "Wrocław",
                    Description = "Ładna restauracja"
                };

                venueRepo.AddVenue(venue);
               await venueRepo.SaveChanges();
               
            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);

             
                Assert.Equal(venueCount + 1, context.Venues.Count());

            }
           
        }

        [Fact]
        public async Task RemoveVenueFromDb()
        {
            var options = new DbContextOptionsBuilder<BoboTuDbContext>()
           .UseInMemoryDatabase($"BoboTuDatabaseForTesting{Guid.NewGuid()}")
           .Options;

            var venueData = System.IO.File.ReadAllText(@"VenueDataSeed/venueDataSeed.json");
            var venues = JsonConvert.DeserializeObject<List<Venue>>(venueData);
            int venueCount = 0;
            using (var context = new BoboTuDbContext(options))
            {
                context.Venues.AddRange(venues);
                context.SaveChanges();
                venueCount = context.Venues.Count();

            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);

                var venue = (await venueRepo.GetAllVenuesAsync(new List<int>().ToArray(), new List<int>().ToArray())).First();

                venueRepo.DeleteVenue(venue);
                await venueRepo.SaveChanges();


            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);


                Assert.Equal(venueCount  -1, context.Venues.Count());

            }

        }

        [Fact]
        public async Task RemoveVenue_Null_ThrowsArgumentException()
        {
            var options = new DbContextOptionsBuilder<BoboTuDbContext>()
          .UseInMemoryDatabase($"BoboTuDatabaseForTesting{Guid.NewGuid()}")
          .Options;

            var venueData = System.IO.File.ReadAllText(@"VenueDataSeed/venueDataSeed.json");
            var venues = JsonConvert.DeserializeObject<List<Venue>>(venueData);
            int venueCount = 0;
            using (var context = new BoboTuDbContext(options))
            {
                context.Venues.AddRange(venues);
                context.SaveChanges();
                venueCount = context.Venues.Count();

            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);



              await  Assert.ThrowsAsync<ArgumentException>(
                     // Act      
                     async () =>
                     {
                         venueRepo.DeleteVenue(null);
                         await venueRepo.SaveChanges();
                     }
                     );
            }

          

            }

        [Fact]
        public async Task AddVenue_Null_ThrowsArgumentException()
        {
            var options = new DbContextOptionsBuilder<BoboTuDbContext>()
          .UseInMemoryDatabase($"BoboTuDatabaseForTesting{Guid.NewGuid()}")
          .Options;

            var venueData = System.IO.File.ReadAllText(@"VenueDataSeed/venueDataSeed.json");
            var venues = JsonConvert.DeserializeObject<List<Venue>>(venueData);
            int venueCount = 0;
            using (var context = new BoboTuDbContext(options))
            {
                context.Venues.AddRange(venues);
                context.SaveChanges();
                venueCount = context.Venues.Count();

            }

            using (var context = new BoboTuDbContext(options))
            {
                var venueRepo = new VenueRepository(context);



                await Assert.ThrowsAsync<ArgumentException>(
                       // Act      
                       async () =>
                       {
                           venueRepo.AddVenue(null);
                           await venueRepo.SaveChanges();
                       }
                       );
            }



        }
    }
    
}
