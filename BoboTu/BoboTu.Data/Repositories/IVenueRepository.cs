using BoboTu.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoboTu.Data.Repositories
{
     public interface IVenueRepository
    {
        void AddVenue(Venue Venue);
        void DeleteVenue(Venue Venue);
        Task<Venue[]> GetAllVenuesAsync();
        Task<Venue> GetVenueAsync(int id);
        Task<bool> SaveChanges();
        Task<IEnumerable<Facility>> GetFacilities(int[] facilitiesIds = null);
        Task<Facility> GetFacility(int facilityId);
    }
}
