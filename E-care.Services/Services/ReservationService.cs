using E_care.Dal;
using E_care.Domain.Abstractions;
using E_care.Domain.Abstractions.Services;
using E_care.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_care.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMedicalCenterRepository _medicalCenterRepository;
        private readonly DataContext _dataContext;
        public ReservationService(IMedicalCenterRepository medicalCenterRepository, DataContext dataContext)
        {
            _medicalCenterRepository = medicalCenterRepository;
            _dataContext = dataContext; 
        }

        public async Task<List<Reservation>> GetAllReservationASync()
        {
            var reservations = await _dataContext.Reservations.ToListAsync();

            return reservations;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservation = await _dataContext.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task<Reservation> MakeReservation(Reservation reservation)
        {     
            var medicalCenter = await _medicalCenterRepository.GetMedicalCenterByIdAsync(reservation.MedicalCenterId);

            var specialist = medicalCenter.Specialists.Where(s => s.SpecialistId == reservation.SpecialistId).FirstOrDefault();
            if (medicalCenter == null || specialist == null)
                return null;

            bool isBusy = await _dataContext.Reservations.AnyAsync(r =>
            (reservation.StartTime >= r.StartTime && reservation.StartTime <= r.EndTime)
            && (reservation.EndTime >= r.StartTime && reservation.EndTime <= r.EndTime));

            if (isBusy)
                return null;

            specialist.BusyFrom = reservation.StartTime;
            specialist.BusyTo = reservation.EndTime;

            //_dataContext.Specialists.Update(specialist);
            _dataContext.Reservations.Add(reservation);

            await _dataContext.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> DeleteReservationByIdAsync(int id)
        {
            var toDelete = await _dataContext.Reservations.FindAsync(id);
            if (toDelete == null)
                return null;

            _dataContext.Remove(toDelete);

            await _dataContext.SaveChangesAsync();

            return toDelete;
        }
    }
}
