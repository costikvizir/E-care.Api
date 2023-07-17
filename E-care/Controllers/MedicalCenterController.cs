using Microsoft.AspNetCore.Mvc;
using E_care.Domain.Models;
using E_care.Dal;
using Microsoft.EntityFrameworkCore;
using E_care.Dtos.Dtos;
using AutoMapper;
using E_care.Domain.Abstractions;

namespace E_care.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalCentersController : Controller
    {
        private readonly IMedicalCenterRepository _medicalCenterRepository;
        private readonly IMapper _mapper;

        public MedicalCentersController(IMedicalCenterRepository medicalCenterRepository, IMapper mapper )
        {
            _medicalCenterRepository = medicalCenterRepository;
            _mapper = mapper;
        }
        [HttpGet]
         public async Task<IActionResult> GetAllMedicalCenters()
         {
             var medicalCenters = await _medicalCenterRepository.GetAllMedicalCentersAsync();
             var getMedicalCenters = _mapper.Map<List<GetMedicalCenterDto>>(medicalCenters);

             return Ok(getMedicalCenters);
         }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMedicalCenterById(int id)
        {
            var medicalCenter = await _medicalCenterRepository.GetMedicalCenterByIdAsync(id);
            var getMedicalCenter = _mapper.Map<GetMedicalCenterDto>(medicalCenter);

            if (getMedicalCenter == null)
               return NotFound("No resource with the corresponding ID found");

            return Ok(getMedicalCenter);
        }

        [Route("{medicalCenterName}")]
        [HttpGet]

        public async Task<IActionResult> GetMedicalCenterByName(string medicalCenterName)
        {
            if (string.IsNullOrEmpty(medicalCenterName))
                return NotFound();

            var medicalCenter = await _medicalCenterRepository.GetMedicalCenterByNameAsync(medicalCenterName);

            var getMedicalCenter = _mapper.Map<GetMedicalCenterDto>(medicalCenter);

            if (getMedicalCenter == null)
                return NotFound("No resource with the corresponding ID found");

            return Ok(getMedicalCenter);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalCenter([FromBody] AddMedicalCenterDto medicalCenter)
        {
            var domainMedicalCenter = _mapper.Map<MedicalCenter>(medicalCenter);

            await _medicalCenterRepository.CreateMedicalCenterAsync(domainMedicalCenter);

            var medicalCenterGet = _mapper.Map<GetMedicalCenterDto>(domainMedicalCenter);
     
            return CreatedAtAction(nameof(GetMedicalCenterById),new {id = domainMedicalCenter.MedicalCenterId } , medicalCenterGet);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMedicalCenter(int id, [FromBody] AddMedicalCenterDto updatedMedicalCenter)
        {
            var toUpdate =  _mapper.Map<MedicalCenter>(updatedMedicalCenter);
            toUpdate.MedicalCenterId = id;

            await _medicalCenterRepository.UpdateMedicalCenterAsync(toUpdate);
 
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMedicalCenter(int id)
        {
            var toDelete = await _medicalCenterRepository.DeleteMedicalCenterAsync(id);            

            if (toDelete == null)
                return NotFound("No resource with the corresponding ID found");

            return NoContent();
        }

        [HttpGet]
        [Route("{medicalCenterId}/specialists")]
        public async Task<IActionResult> GetAllSpecialists(int medicalCenterId)
        {
            var specialists = await _medicalCenterRepository.GetAllSpecialistsAsync(medicalCenterId);
            var mappedSpecialists = _mapper.Map<List<GetSpecialistDto>>(specialists); 

            return Ok(mappedSpecialists );
        }

        [HttpGet]
        [Route("{medicalCenterId}/specialists/{specialistId}")]
        public async Task<IActionResult> GetSpecialistById(int medicalCenterId, int specialistId)
        {
            var specialist = await _medicalCenterRepository.GetSpecialistByIdAsync(medicalCenterId, specialistId);  

            if (specialist is null)
                return NotFound("Specialist Not Found");

            var mappedSpecialist = _mapper.Map<GetSpecialistDto>(specialist);

            return Ok(mappedSpecialist);
        }

        [HttpPost]
        [Route("{medicalCenterId}/specialists")]

        public async  Task<IActionResult> AddSpecialist(int medicalCenterId, [FromBody] AddSpecialistDto newSpecialist)
        {
            var specialist = _mapper.Map<Specialist>(newSpecialist);

            await _medicalCenterRepository.CreateSpecialistAsync(medicalCenterId, specialist);

            var mappedSpecialist = _mapper.Map<GetSpecialistDto>(specialist);
            //return Ok();
            //return CreatedAtAction(nameof(GetSpecialistById), 
              //  new { medicalCenterId = medicalCenterId, specialisId = mappedSpecialist.SpecialistId }, mappedSpecialist);
            return CreatedAtAction(nameof(AddSpecialist), mappedSpecialist);
        }

        [HttpPut]
        [Route("{medicalCenterId}/specialists/{specialistId}")]
        public async Task<IActionResult> UpdateSpecialist(int medicalCenterId, int specialistId,
            [FromBody] AddSpecialistDto updatedSpecialist)
        {
            var toUpdate = _mapper.Map<Specialist>(updatedSpecialist);
            toUpdate.SpecialistId = specialistId;
            toUpdate.MedicalCenterId= medicalCenterId;
            
            await _medicalCenterRepository.UpdateSpecialistByIdAsync(medicalCenterId, toUpdate);

            return NoContent();
        } 

        [HttpDelete]
        [Route("{medicalCenterId}/specialists/{specialistId}")]
        public async Task<IActionResult> RemoveSpecialist(int medicalCenterId, int specialistId)
        {
            var specialist = await _medicalCenterRepository.DeleteSpecialistByIdAsync(medicalCenterId,specialistId);

            if (specialist == null)
                return NotFound("Specialist Not Found");

            return NoContent();
        }
    }
}
