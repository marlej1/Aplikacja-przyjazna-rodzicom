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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/venues")]
    [AllowAnonymous]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public VenuesController(IVenueRepository venueRepository, IMapper mapper, ILogger<VenuesController> logger)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get All venues
        /// </summary>
        /// <param name="facilityIds"></param>
        /// <param name="venueTypeIds"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenues(string facilityIds, string venueTypeIds)
        {



            try
            {

                throw new Exception("Bład połaczenia z bazą dzisiak");

                int[] facilityIdArray = facilityIds == null ? new int[0] : facilityIds.Split(',').Select(id => int.Parse(id)).ToArray();

                int[] venueTypeIdsArray = venueTypeIds == null ? new int[0] : venueTypeIds.Split(',').Select(id => int.Parse(id)).ToArray();

                var venuesFromRepo = await _venueRepository.GetAllVenuesAsync(facilityIdArray, venueTypeIdsArray);
                return Ok(_mapper.Map<IEnumerable<VenueDto>>(venuesFromRepo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
        
            }
        
        }
        /// <summary>
        /// Get venue by id
        /// </summary>
        /// <param name="venueId"></param>
        /// <returns></returns>
        [HttpGet("{venueId}", Name = "GetVenue")]
        public async Task<IActionResult> GetVenue(int venueId)
        {
            var venueFromRepo = await _venueRepository.GetVenueAsync(venueId);

            if (venueFromRepo == null)
            {
                return NotFound();
            }
            try
            {
                var result = _mapper.Map<VenueDto>(venueFromRepo);

              var grouping =  venueFromRepo.Ratings.Select(r => r.Value).GroupBy(rat => rat).Select(r=>   (r.Key, r.Count())  );
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
            }

        }

        /// <summary>
        /// Create new venue
        /// </summary>
        /// <param name="venue"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<VenueDto>> CreateVenue(VenueForCreationDto venue)
        {
            var venueEntity = _mapper.Map<Venue>(venue);



            try
            {
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
            }
      

            _venueRepository.AddVenue(venueEntity);
            await _venueRepository.SaveChanges();

            var venueToReturn = _mapper.Map<VenueDto>(venueEntity);
            return CreatedAtRoute("GetVenue",
                new { venueId = venueToReturn.Id },
                venueToReturn);
        }
        /// <summary>
        /// Update venue with specific properties
        /// </summary>
        /// <param name="venueId"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [HttpPatch("{venueId}")]
        public async Task<ActionResult> UpdateVenue(int venueId,  JsonPatchDocument<VenueForUpdate> patchDocument)
        {
            try
            {
                var venueFromRepo = await _venueRepository.GetVenueAsync(venueId);

                if (venueFromRepo == null)
                {
                    return NotFound();
                }

                var venueToUpdate = _mapper.Map<VenueForUpdate>(venueFromRepo);

                patchDocument.ApplyTo(venueToUpdate);

                _mapper.Map(venueToUpdate, venueFromRepo);
                await _venueRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
            }
          

        }


    }
}
