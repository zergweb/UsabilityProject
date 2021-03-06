﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsabilityProject.Model
{
    public class SampleToJson
    {
        public int Id { get; set; }
        public String Date { get; set; }
       // public String Pressure { get; set; }
        public float? Temperature { get; set; }
        public int? Pulse { get; set; }
       // public int? AppUserId { get; set; }
        public AppUser User { get; set; }
        public int StressFactor { get; set; }
    }
}
