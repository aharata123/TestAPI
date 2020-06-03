﻿using System;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public partial class StackHolerDetail
    {
        public string StackHolerId { get; set; }
        public string CompanyId { get; set; }
        public double? ShmarketSalary { get; set; }
        public double? Shsalary { get; set; }
        public string Shjob { get; set; }
        public string ShnameForCompany { get; set; }
        public string Shimage { get; set; }
        public string ShemailVerify { get; set; }

        public virtual Company Company { get; set; }
        public virtual StackHolder StackHoler { get; set; }
    }
}
