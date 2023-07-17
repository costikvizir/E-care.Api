using AutoMapper;
using E_care.Domain.Abstractions.Repositories;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace E_care.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] ClientPostDto user)
        {
            var domainUser = _mapper.Map<Client>(user);
            await _userRepository.CreateUserAsync(domainUser);

            return Ok(domainUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] ClientPostDto user)
        {
            var domainUser = _mapper.Map<Client>(user);
            await _userRepository.UpdateUserAsync(domainUser);

            return Ok(domainUser);
        }

    }
}
