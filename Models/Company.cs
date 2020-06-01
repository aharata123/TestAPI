using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Company
    {
        public Company()
        {
            Assets = new HashSet<Asset>();
            Members = new HashSet<Member>();
            Projects = new HashSet<Project>();
        }

        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ComapnyIcon { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
