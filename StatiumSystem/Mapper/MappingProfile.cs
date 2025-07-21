using AutoMapper;
using StatiumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumSystem.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StadiumDTO, Stadium>();
            CreateMap<Stadium, StadiumDTO>();
            CreateMap<ReservationDTO, Reservation>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<Reservation, ReservationViewDTO>()
               .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.Name))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)); // ✅ إضافة هذه السطر
            CreateMap<Reservation, ReservationFullViewDTO>()
               .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.Name))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
