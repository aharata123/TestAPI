﻿using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class TypeAsset
    {
        public TypeAsset()
        {
            SliceAssets = new HashSet<SliceAsset>();
        }

        public int TypeAssetId { get; set; }
        public string NameAsset { get; set; }
        public int Multiplier { get; set; }
        public string MultiplierType { get; set; }

        public virtual ICollection<SliceAsset> SliceAssets { get; set; }
    }
}
