using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public Office Office { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
