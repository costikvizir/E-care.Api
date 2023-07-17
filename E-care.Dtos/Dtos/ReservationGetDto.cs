using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dtos.Dtos
{
    public class ReservationGetDto
    {
        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public int SpecialistId { get; set; }
        public int MedicalCenterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
