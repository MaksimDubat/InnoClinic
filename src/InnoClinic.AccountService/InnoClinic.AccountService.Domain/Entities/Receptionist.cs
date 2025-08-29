using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Domain.Entities
{
    public class Receptionist
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public int? OfficeId { get; set; }
        public Office? Office { get; set; }
    }
}
