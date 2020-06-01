using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class Asset
    {
        public string AssetId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public DateTime TimeAsset { get; set; }
        public int MultiplierInTime { get; set; }
        public string MemberId { get; set; }
        public string CompanyId { get; set; }
        public string ProjectId { get; set; }
        public int? TypeAssetId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public virtual TypeAsset TypeAsset { get; set; }
    }
}
