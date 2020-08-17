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

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/venues/{venueId}/opinions")]
    [AllowAnonymous]
    public class OpinionsController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;

        public OpinionsController(IVenueRepository venueRepository, IMapper mapper)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<OpinionDto>>> GetOpinions(int venueId)
        {
            var opinionsFromRepo = await _venueRepository.GetOpinionsForVenue(venueId);
            var ratings = await _venueRepository.GetRatingsForVenue(venueId);

            var opinionsAndRatings =    _mapper.Map<IEnumerable<OpinionDto>>(opinionsFromRepo);

            foreach (var opinion in opinionsAndRatings)
            {

              var rating =   ratings.LastOrDefault(r => r.UserId == opinion.UserId);
                if(rating != null)
                {
                    opinion.UsersRating = rating.Value;

                }
            }
            return Ok(opinionsAndRatings);
        }
    }
}