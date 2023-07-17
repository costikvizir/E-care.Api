using AutoMapper;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;

namespace E_care.Automapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<ReservationPutPostDto, Reservation>();

            CreateMap<Reservation, ReservationGetDto>();
        }
    }
}
