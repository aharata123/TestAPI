using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }

        public int RoleId { get; set; }
        public string NameRole { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
