using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoboTu.Data.Repositories;
using BoboTu.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/venues/{venueId}/opinions")]
    [AllowAnonymous]
    public class OpinionsController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public OpinionsController(IVenueRepository venueRepository, IMapper mapper, ILogger<OpinionsController> logger)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
            _logger = logger;

        }
        /// <summary>
        /// Get all opinions
        /// </summary>
        /// <param name="venueId"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<OpinionDto>>> GetOpinions(int venueId)
        {

            try
            {
                var opinionsFromRepo = await _venueRepository.GetOpinionsForVenue(venueId);
                var ratings = await _venueRepository.GetRatingsForVenue(venueId);

                var opinionsAndRatings = _mapper.Map<IEnumerable<OpinionDto>>(opinionsFromRepo);

                foreach (var opinion in opinionsAndRatings)
                {

                    var rating = ratings.LastOrDefault(r => r.UserId == opinion.UserId);
                    if (rating != null)
                    {
                        opinion.UsersRating = rating.Value;

                    }
                }
                return Ok(opinionsAndRatings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
            }
        
        }
    }
}