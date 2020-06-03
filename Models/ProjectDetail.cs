using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class ProjectDetail
    {
        public int TermId { get; set; }
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual TermSlouse Term { get; set; }
    }
}
