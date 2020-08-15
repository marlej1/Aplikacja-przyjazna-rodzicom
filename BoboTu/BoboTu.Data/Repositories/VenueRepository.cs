using BoboTu.Data.Models;
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
            _boboTuDb.Add(venue);
        }

        public void DeleteVenue(Venue venue)
        {
            _boboTuDb.Remove(venue);
        }

        public async Task<Venue[]> GetAllVenuesAsync()
        {
           return await  _boboTuDb.Venues.Include(v => v.Ratings).Include(v => v.Opinions).Include(v => v.VenueFacilities).ThenInclude(vf=>vf.Facility).ToArrayAsync();

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
