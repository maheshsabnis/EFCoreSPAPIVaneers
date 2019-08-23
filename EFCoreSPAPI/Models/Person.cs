using System;
using System.Collections.Generic;

namespace EFCoreSPAPI.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string ResidenceNo { get; set; }
        public string ResidenceName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
