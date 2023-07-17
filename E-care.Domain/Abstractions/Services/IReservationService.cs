using E_care.Domain.Models;

namespace E_care.Domain.Abstractions.Services
{
    public interface IReservationService
    {
        Task<Reservation> MakeReservation(Reservation reservation);
        Task<List<Reservation>> GetAllReservationASync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<Reservation> DeleteReservationByIdAsync(int id);
    }
}
