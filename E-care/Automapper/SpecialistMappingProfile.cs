using AutoMapper;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;

namespace E_care.Automapper
{
    public class SpecialistMappingProfile : Profile
    {
        public SpecialistMappingProfile()
        {
            CreateMap<AddSpecialistDto, Specialist>();

            CreateMap<Specialist, GetSpecialistDto>();
        }
    }
}
