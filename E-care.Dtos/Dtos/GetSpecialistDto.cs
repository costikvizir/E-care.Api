using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dtos.Dtos
{
    public class GetSpecialistDto
    {
        [Required]
        public int SpecialistId { get; set; }

        [Required]
        public string SpecialistName { get; set; }

        [Required]
        public string Speciality { get; set; }

        [Required]
        public int MedicalCenterId { get; set; }
    }
}
