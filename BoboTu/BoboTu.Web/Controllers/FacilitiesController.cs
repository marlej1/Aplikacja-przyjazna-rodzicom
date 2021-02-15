using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoboTu.Data.Models;
using BoboTu.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoboTu.Web.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    [AllowAnonymous]
    public class FacilitiesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly ILogger _logger;


        public FacilitiesController(IVenueRepository venueRepository, ILogger<FacilitiesController> logger)
        {
            _venueRepository = venueRepository;
            _logger = logger;


        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {

            try
            {
                return Ok(await _venueRepository.GetFacilities());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Wystąpił nieznany błąd");
            }
        }
    }
}