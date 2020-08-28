using BoboTu.Data.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoboTu.Data.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly BoboTuDbContext _boboTuDb;

        public VenueRepository(BoboTuDbContext boboTuDb)
        {
            _boboTuDb = boboTuDb;
        }
        public void AddVenue(Venue venue)
        {

            if (venue == null)
            {
                throw new ArgumentException( nameof(venue));
            }
             _boboTuDb.Add(venue);
        }

        public void DeleteVenue(Venue venue)
        {

            if (venue == null)
            {
                throw new ArgumentException(nameof(venue));
            }
            _boboTuDb.Remove(venue);
        }

        public async Task<Venue[]> GetAllVenuesAsync( int[] facilityIds, int[] venueTypeIds)
        {
            var collection = _boboTuDb.Venues.Include(v => v.Ratings).Include(v => v.Opinions).Include(v => v.VenueFacilities).ThenInclude(vf => vf.Facility) as IQueryable<Venue>;
            if (venueTypeIds.Any())
            {
                collection = collection.Where(v => venueTypeIds.Contains((int)v.VenueType));
            }



            if (facilityIds.Any())
            {
                var venuePredicate = PredicateBuilder.New<Venue>();

                foreach (var id in facilityIds)
                {
                    venuePredicate = venuePredicate.And(m => m.VenueFacilities
                                       .Any(vf => vf.FacilityId == id
                                              ));
                }

                //    var result = collection.AsEnumerable().Where(v => !facilityIds.Except(v.VenueFacilities.Select(f => f.FacilityId)).Any());
                collection = collection.Where(venuePredicate);

                //return await Task.FromResult(result.ToArray());
            }
            return await collection.ToArrayAsync();

        }

        public async Task<IEnumerable<Facility>> GetFacilities(int[] facilitiesIds = null)
        {
            try
            {

                if(facilitiesIds == null)
                {
                    return await _boboTuDb.Facilities.ToListAsync();
                }
                return await _boboTuDb.Facilities.Where(x => facilitiesIds.Contains(x.Id)).ToListAsync();


            }
            catch (Exception ex)
            {

                throw;
            };    
           
        }

        public Task<IEnumerable<Facility>> GetFacilities()
        {
            throw new NotImplementedException();
        }

        public async Task<Facility> GetFacility(int facilityId)
        {
            return await _boboTuDb.Facilities.FirstOrDefaultAsync(f => f.Id == facilityId);
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForVenue(int venueId)
        {
            return await _boboTuDb.Opinions.Where(o => o.VenueId == venueId).ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsForVenue(int venueId)
        {
            return await _boboTuDb.Ratings.Where(o => o.VenueId == venueId).ToListAsync();

        }

        public async Task<Venue> GetVenueAsync(int id)
        {

            return await _boboTuDb.Venues.Include(v=>v.Ratings).Include(v=>v.Opinions).Include(v=>v.VenueFacilities).ThenInclude(vf=>vf.Facility).FirstOrDefaultAsync(v => v.Id == id);
        }

        public  async Task<bool> SaveChanges()
        {
            return 0 < (await _boboTuDb.SaveChangesAsync());

        }
    }
}
