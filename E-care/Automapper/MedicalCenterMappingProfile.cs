using AutoMapper;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;

namespace E_care.Automapper
{
    public class MedicalCenterMappingProfile : Profile
    {
        public MedicalCenterMappingProfile()
        {
            CreateMap<AddMedicalCenterDto, MedicalCenter>();

            CreateMap<MedicalCenter, GetMedicalCenterDto>();
        }
    }
}
