using E_care.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dtos.Dtos
{
    public class AddMedicalCenterDto
    {
        [Required]
        public string MedicalCenterName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
