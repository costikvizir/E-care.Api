using AutoMapper;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;

namespace E_care.Automapper
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientPostDto, Client>();
        }
    }
}
