using E_care.Domain.Models;


namespace E_care.Domain.Abstractions.Repositories
{
    public interface IReservationRepository
    {
        public Task<Reservation> MakeReservationAsync(Reservation reservation);
        public Task<List<Reservation>> GetAllReservationsAsync();
        public Task<Reservation> GetReservationByIdAsync(int id);
        public Task<Reservation> RemoveReservationAsync(int id);
    }
}
