using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CardCost.Core.Entities
{
    public partial class Iinlist
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public string Country { get; set; }
    }
}
