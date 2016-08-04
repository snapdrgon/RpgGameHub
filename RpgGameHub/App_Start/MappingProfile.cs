using AutoMapper;
using RpgGameHub.Core.Dtos;
using RpgGameHub.Core.Models;

namespace RpgGameHub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Meetup, MeetupDto>();
         }

    }
}