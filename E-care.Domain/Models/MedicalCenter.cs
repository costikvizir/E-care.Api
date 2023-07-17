using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Domain.Models
{
    public class MedicalCenter
    {
        public int MedicalCenterId { get; set; }
        public string MedicalCenterName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public List<Specialist>? Specialists { get; set; }

    }
}
