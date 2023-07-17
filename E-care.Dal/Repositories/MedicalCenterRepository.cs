using E_care.Domain.Abstractions;
using E_care.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_care.Dal.Repositories
{
    public class MedicalCenterRepository : IMedicalCenterRepository
    {
        private readonly DataContext _dataContext;
        public MedicalCenterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<MedicalCenter> CreateMedicalCenterAsync(MedicalCenter medicalCenter)
        {
            _dataContext.Add(medicalCenter);
            await _dataContext.SaveChangesAsync();

            return medicalCenter;
        }

        public async Task<Specialist> CreateSpecialistAsync(int medicalCenterId, Specialist specialist)
        {
            var medicalCenter = await _dataContext.MedicalCenters.Include(m => m.Specialists)
                .FirstOrDefaultAsync(m => m.MedicalCenterId == medicalCenterId);

            medicalCenter.Specialists.Add(specialist);

            return specialist;
        }

        public async Task<MedicalCenter> DeleteMedicalCenterAsync(int medicalCenterId)
        {
            var toDelete = await _dataContext.MedicalCenters.FindAsync(medicalCenterId);

            if (toDelete == null)
                return null;

            _dataContext.Remove(toDelete);
            await _dataContext.SaveChangesAsync();

            return toDelete;
        }

        public async Task<Specialist> DeleteSpecialistByIdAsync(int medicalCenterId, int specialistId)
        {
            var specialist = await _dataContext.Specialists.FirstOrDefaultAsync(
               s => s.MedicalCenterId == medicalCenterId && s.SpecialistId == specialistId);

            if (specialist == null)
                return null;

            _dataContext.Specialists.Remove(specialist);

            await _dataContext.SaveChangesAsync();

            return specialist;
        }

        public async Task<List<MedicalCenter>> GetAllMedicalCentersAsync()
        {
            var medicalCenters = await _dataContext.MedicalCenters.ToListAsync();

            return medicalCenters;
        }

        public async Task<List<Specialist>> GetAllSpecialistsAsync(int medicalCenterId)
        {
            var specialists = await _dataContext.Specialists.Where(s => s.MedicalCenterId == medicalCenterId).ToListAsync();

            return specialists;
        }

        public async Task<MedicalCenter> GetMedicalCenterByIdAsync(int medicalCenterId)
        {
            var medicalCenter = await _dataContext.MedicalCenters
                .Include(m => m.Specialists).FirstOrDefaultAsync(m => m.MedicalCenterId == medicalCenterId);

            if (medicalCenter == null)
                return null;

            return medicalCenter;
        }

        public async Task<MedicalCenter> GetMedicalCenterByNameAsync(string medicalCenterName)
        {
            var medicalCenter = await _dataContext.MedicalCenters
                .Include(m => m.Specialists).FirstOrDefaultAsync(m => m.MedicalCenterName == medicalCenterName);

            if (medicalCenter == null)
                return null;

            return medicalCenter;
        }

        public async Task<Specialist> GetSpecialistByIdAsync(int medicalCenterId, int specialistId)
        {
            var specialist = await _dataContext.Specialists.
                FirstOrDefaultAsync(s => s.MedicalCenterId == medicalCenterId && s.SpecialistId == specialistId);

            if (specialist is null)
                return null;

            return specialist;
        }

        public async Task<MedicalCenter> UpdateMedicalCenterAsync(MedicalCenter medicalCenter)
        {
            _dataContext.Update(medicalCenter);
            await _dataContext.SaveChangesAsync();

            return medicalCenter;
        }

        public async Task<Specialist> UpdateSpecialistByIdAsync(int medicalCenterId, Specialist specialist)
        {
            _dataContext.Update(specialist);
            await _dataContext.SaveChangesAsync();

            return specialist;
        }
    }
}
