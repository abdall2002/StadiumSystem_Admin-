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
            CreateMap<ReservationDTO, Reservation>();
        }
    }
}
