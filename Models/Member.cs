using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Member
    {
        public Member()
        {
            Assets = new HashSet<Asset>();
        }

        public string MemberId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNo { get; set; }
        public string Job { get; set; }
        public double? MarketSalary { get; set; }
        public double? Salary { get; set; }
        public string StatusId { get; set; }
        public int? RoleId { get; set; }
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
