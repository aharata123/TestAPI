using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.DTO
{
    public class MemberDTO 
    {
        public string MemberId { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNo { get; set; }
        public string Job { get; set; }
        public double? MarketSalary { get; set; }
        public double? Salary { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public virtual ICollection<AssetDTO> Assets { get; set; }

        public virtual string CompanyName { get; set; }

        
    }
}
