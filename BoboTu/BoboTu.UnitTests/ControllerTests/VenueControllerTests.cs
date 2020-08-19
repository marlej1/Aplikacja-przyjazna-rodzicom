using AutoMapper;
using BoboTu.Data.Repositories;
using BoboTu.Web.AutomapperProfiles;
using BoboTu.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BoboTu.UnitTests.ControllerTests
{
    public class VenueControllerTests
    {
        [Fact]
        public async Task ShouldReturnNotFoundStatus()
        {

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VenueProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            var moqRepo = new Mock<IVenueRepository>().Object;


            var controller = new VenuesController(moqRepo, mapper);


            var res = await controller.GetVenue(-1);
            var notFound = res as NotFoundResult;

            Assert.NotNull(notFound);
            Assert.Equal(404, notFound.StatusCode);


        }
    }
}
