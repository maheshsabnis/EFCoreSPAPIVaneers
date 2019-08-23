using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreSPAPI.Models;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExtras.EF7;
using System.Data.SqlClient;

namespace EFCoreSPAPI.Services
{
    public interface IPersonService
    {
        int InsertPerson(PersonTableType     person);
    }
    public class PersonService : IPersonService
    {
        private readonly ApplicationContext context;

        public PersonService(ApplicationContext context)
        {
            this.context = context;
        }
        public int InsertPerson(PersonTableType person)
        {
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Direction = System.Data.ParameterDirection.Output;

                var proc = new spInsertPerson()
                {
                    Id = 0,
                     PersonAddress = new List<PersonTableType>() { person }
                };
                  var res =  context.Database.ExecuteStoredProcedure<spInsertPerson>(proc);
                var resultId = proc.Id;
               
                return resultId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
