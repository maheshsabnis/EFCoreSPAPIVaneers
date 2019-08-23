using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF7;
namespace EFCoreSPAPI.Models
{
    [UserDefinedTableType("PersonTableType")]
    public class PersonTableType
    {
        [UserDefinedTableTypeColumn(1)]
        public string PersonId { get; set; }
        [UserDefinedTableTypeColumn(2)]
        public string PersonName { get; set; }
        [UserDefinedTableTypeColumn(3)]
        public string ResidenceNo { get; set; }
        [UserDefinedTableTypeColumn(4)]
        public string ResidenceName { get; set; }
        [UserDefinedTableTypeColumn(5)]
        public string Street { get; set; }
        [UserDefinedTableTypeColumn(6)]
        public string City { get; set; }
    }
}
