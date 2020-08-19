using AutoMapper;
using BoboTu.Data.Repositories;
using BoboTu.Web.AutomapperProfiles;
using BoboTu.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace BoboTu.Tests.Controller.Tests
{
    [TestFixture]
    class VenueControllerTests
    {
        [Test]
        public async Task ShouldReturnNotFoundStatus()
        {

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VenueProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            var moqRepo = new Mock<IVenueRepository>().Object;
      

            var controller = new VenuesController(moqRepo, mapper);


           var res =  await controller.GetVenue(-1);
            var notFound = res as NotFoundResult;

            Assert.IsNotNull(notFound);
            Assert.AreEqual(404, notFound.StatusCode);


        }

         
    }
}
