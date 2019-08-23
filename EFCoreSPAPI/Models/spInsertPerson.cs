using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF7;
namespace EFCoreSPAPI.Models
{
    [StoredProcedure("spInsertPerson")]
    public class spInsertPerson
    {
        [StoredProcedureParameter(System.Data.SqlDbType.Int, ParameterName = "Id", Direction = System.Data.ParameterDirection.Output)]
        public int Id { get; set; }
        [StoredProcedureParameter(System.Data.SqlDbType.Structured,ParameterName ="PersonAddress")]
        public List<PersonTableType> PersonAddress { get; set; }
    }
}
