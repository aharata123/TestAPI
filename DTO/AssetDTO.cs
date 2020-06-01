using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTO
{
    public class AssetDTO
    {
        public double Quantity { get; set; }
        public string Description { get; set; }
        public DateTime TimeAsset { get; set; }
    }
}
