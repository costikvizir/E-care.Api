using E_care.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Domain.Abstractions
{
    public interface IMedicalCenterRepository
    {
        Task<List<MedicalCenter>> GetAllMedicalCentersAsync();
        Task<MedicalCenter> GetMedicalCenterByIdAsync(int medicalCenterId);
        Task<MedicalCenter> CreateMedicalCenterAsync(MedicalCenter medicalCenter);
        Task<MedicalCenter> UpdateMedicalCenterAsync(MedicalCenter medicalCenter);
        Task<MedicalCenter> DeleteMedicalCenterAsync(int medicalCenterId);
        Task<List<Specialist>> GetAllSpecialistsAsync(int medicalCenterId);
        Task<Specialist> GetSpecialistByIdAsync(int medicalCenterId, int specialistId);
        Task<Specialist> CreateSpecialistAsync(int medicalCenterId, Specialist specialist);
        Task<Specialist> UpdateSpecialistByIdAsync(int medicalCenterId, Specialist specialist);
        Task<Specialist> DeleteSpecialistByIdAsync(int medicalCenterId, int specialistId);
        Task<MedicalCenter> GetMedicalCenterByNameAsync(string medicalCenterName);
    }
}
