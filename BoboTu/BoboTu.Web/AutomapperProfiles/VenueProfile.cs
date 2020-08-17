using AutoMapper;
using BoboTu.Data.Models;
using BoboTu.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.AutomapperProfiles
{
    public class VenueProfile : Profile
    {

        public VenueProfile()
        {
            CreateMap<Venue, VenueDto>().ForMember(v => v.Facilities, opt =>
              {
                  opt.MapFrom(s => s.VenueFacilities.Select(vf => new FacilityDto() { Id = vf.FacilityId, Name = vf.Facility.Name }).ToList());
              }).ForMember(
                v => v.AverageRating, opt =>
                {
                    opt.MapFrom(s => s.Ratings.Count() == 0 ? 0d : Math.Round(s.Ratings.Select(r => r.Value).Average(), 2));
                })
              .ForMember(
                v => v.CountOfValueRatings, opt =>
                {
                    opt.MapFrom(s => s.Ratings.Select(r => r.Value).GroupBy(rat => rat).Select(r => new CountOfValueRating() { Count = r.Count(), RatingValue = r.Key }));
                })
              .ForMember(
                v => v.RatingsCount, opt =>
                {
                    opt.MapFrom(s => s.Ratings.Select(r => r.Value).Count());
                });



            CreateMap<VenueForCreationDto, Venue>().ReverseMap();
            CreateMap<VenueForUpdate, Venue>().ReverseMap();

            CreateMap<RatingDto, Venue>().ReverseMap();
            CreateMap<VenueForCreationDto, Venue>();
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<OpinionDto, Opinion>().ReverseMap();

        }

    }
}
