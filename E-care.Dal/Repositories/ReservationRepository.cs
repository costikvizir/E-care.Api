using E_care.Domain.Abstractions;
using E_care.Domain.Abstractions.Repositories;
using E_care.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dal.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMedicalCenterRepository _medicalCenterRepository;

        public ReservationRepository(DataContext dataContext, IMedicalCenterRepository medicalCenterRepository)
        {
            _dataContext = dataContext;
            _medicalCenterRepository = medicalCenterRepository;
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await _dataContext.Reservations.ToListAsync();

            return reservations;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservation = await _dataContext.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task<Reservation> MakeReservationAsync(Reservation reservation)
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

        public async Task<Reservation> RemoveReservationAsync(int id)
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
