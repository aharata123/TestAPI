using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Status
    {
        public Status()
        {
            Members = new HashSet<Member>();
        }

        public string StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
