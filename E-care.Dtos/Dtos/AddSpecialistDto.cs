using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dtos.Dtos
{
    public class AddSpecialistDto
    {
        [Required]
        public string SpecialistName { get; set; }

        [Required]
        public string Speciality { get; set; }
    }
}
