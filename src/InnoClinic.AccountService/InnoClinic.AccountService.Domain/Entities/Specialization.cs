using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Domain.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
