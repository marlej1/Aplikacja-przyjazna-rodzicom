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
        Task<Venue[]> GetAllVenuesAsync(int[] venueTypeIds, int[] facilityIds);
        Task<Venue> GetVenueAsync(int id);
        Task<bool> SaveChanges();
        Task<IEnumerable<Facility>> GetFacilities(int[] facilitiesIds = null);
        Task<IEnumerable<Opinion>> GetOpinionsForVenue(int venueId);

        Task<Facility> GetFacility(int facilityId);
        Task<IEnumerable<Rating>> GetRatingsForVenue(int venueId);
    }
}
