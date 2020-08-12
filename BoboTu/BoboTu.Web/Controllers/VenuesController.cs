using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoboTu.Data.Models;
using BoboTu.Data.Repositories;
using BoboTu.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/venues")]
    [AllowAnonymous]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;


        public VenuesController(IVenueRepository venueRepository, IMapper mapper)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenues()
        {
            var venuesFromRepo = await _venueRepository.GetAllVenuesAsync();
            return Ok(_mapper.Map<IEnumerable<VenueDto>>(venuesFromRepo));
        }

        [HttpGet("{venueId}", Name = "GetVenue")]
        public async Task<ActionResult<VenueDto>> GetVenue(int venueId)
        {
            var venueFromRepo = await _venueRepository.GetVenueAsync(venueId);

            if (venueFromRepo == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(_mapper.Map<VenueDto>(venueFromRepo));

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult<VenueDto>> CreateVenue(VenueForCreationDto venue)
        {
            var venueEntity = _mapper.Map<Venue>(venue);

            venueEntity.Opinions.Add(_mapper.Map<Opinion>(venue.Opinion));
            venueEntity.Ratings.Add(_mapper.Map<Rating>(venue.Rating));

            if (venue.FacilitiesIds.Any())
            {

                foreach (var facilityId in venue.FacilitiesIds)
                {

                    var facility = await _venueRepository.GetFacility(facilityId);


                    facility.VenueFacilities.Add(new VenueFacility()
                    {
                        Facility = facility,
                        Venue = venueEntity
                    });
                }



            }

            _venueRepository.AddVenue(venueEntity);
            await _venueRepository.SaveChanges();

            var venueToReturn = _mapper.Map<VenueDto>(venueEntity);
            return CreatedAtRoute("GetVenue",
                new { venueId = venueToReturn.Id },
                venueToReturn);
        }


    }
}
