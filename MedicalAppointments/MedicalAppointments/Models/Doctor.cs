using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public bool Availability { get; set; }
        public override string ToString() => FullName;
    }
}
