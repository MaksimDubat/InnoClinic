using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool IsEmailVerified { get; set; } = false;
        public int? PhotoId { get; set; }
        public Photo? Photo { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public Receptionist? Receptionist { get; set; }

    }
}
