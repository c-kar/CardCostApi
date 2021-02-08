using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CardCost.Core.Entities
{
    public partial class Ccmatrix
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public float? Cost { get; set; }
    }
}
