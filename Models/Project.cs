using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            Assets = new HashSet<Asset>();
        }

        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
