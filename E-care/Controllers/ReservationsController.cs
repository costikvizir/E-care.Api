using AutoMapper;
using E_care.Domain.Abstractions.Repositories;
using E_care.Domain.Models;
using E_care.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace E_care.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationPutPostDto reservationGetDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationGetDto);
            var result = await _reservationRepository.MakeReservationAsync(reservation);   

            if(result == null)
                return BadRequest("Cannot Create a Reservation");

            var getReservation = _mapper.Map<ReservationGetDto>(result);

            return Ok(getReservation );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync();

            var getReservations = _mapper.Map<List<ReservationGetDto>>(reservations);

            return Ok(getReservations);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id); 

            var getReservation = _mapper.Map<ReservationGetDto>(reservation);

            if(getReservation == null)
                return NotFound("Reservation Not Found");

            return Ok(getReservation);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var toDelete = await _reservationRepository.RemoveReservationAsync(id);

            if (toDelete == null)
                return NotFound("No resource with the corresponding ID found");

            return NoContent();
        }
    }
}
