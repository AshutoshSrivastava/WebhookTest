using AirLineWeb.Dtos;
using AirLineWeb.Models;
using AutoMapper;

namespace AirLineWeb.Profiles
{

    public class FlightDetailProfile : Profile
    {
        public FlightDetailProfile()
        {
            // source -> Target
            CreateMap<FlightDetail, FlightDetailReadDto>();
            CreateMap<FlightDetailCreateDto, FlightDetail>();
            CreateMap<FlightDetailUpdateDto, FlightDetail>();
        }

    }
}