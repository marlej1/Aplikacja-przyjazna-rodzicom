using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoboTu.Data.Models;
using BoboTu.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    [AllowAnonymous]
    public class FacilitiesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;

        public FacilitiesController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;

        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {
            
            return Ok(await _venueRepository.GetFacilities());
        }
    }
}