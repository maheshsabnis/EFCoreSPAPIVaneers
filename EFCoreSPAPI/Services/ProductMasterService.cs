using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EFCoreSPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSPAPI.Services
{
    public interface IProductMasterService
    {
        Task<int> CreateAsync(ProductMaster prd);
        Task<IEnumerable<ProductMaster>> GetAsync();
    }

    public class ProductMasterService : IProductMasterService
    {
        private readonly ApplicationContext context;

        public ProductMasterService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(ProductMaster prd)
        {

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@Id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Direction = System.Data.ParameterDirection.Output;

            SqlParameter pPrdId = new SqlParameter();
            pPrdId.ParameterName = "@ProductId";
            pPrdId.SqlDbType = System.Data.SqlDbType.Text;
            pPrdId.Size = 10;
            pPrdId.Value = prd.ProductId;
            pPrdId.Direction = System.Data.ParameterDirection.Input;

            SqlParameter pPrdName = new SqlParameter();
            pPrdName.ParameterName = "@ProductName";
            pPrdName.SqlDbType = System.Data.SqlDbType.Text;
            pPrdName.Size = 50;
            pPrdName.Value = prd.ProductName;
            pPrdName.Direction = System.Data.ParameterDirection.Input;

            SqlParameter pCatName = new SqlParameter();
            pCatName.ParameterName = "@CategoryName";
            pCatName.SqlDbType = System.Data.SqlDbType.Text;
            pCatName.Size = 50;
            pCatName.Value = prd.CategoryName;
            pCatName.Direction = System.Data.ParameterDirection.Input;

            SqlParameter pPrice = new SqlParameter();
            pPrice.ParameterName = "@Price";
            pPrice.SqlDbType = System.Data.SqlDbType.Int;
            pPrice.Value = prd.Price;
            pPrice.Direction = System.Data.ParameterDirection.Input;

           
            var result = await context.Database.ExecuteSqlCommandAsync("spInsertProduct @Id OUT, @ProductId, @ProductName, @CategoryName, @Price",
                  new object[] {pId, pPrdId,pPrdName,pCatName,pPrice });
            var res = pId.Value;
            return (int)res;
        }
        public async Task<IEnumerable<ProductMaster>> GetAsync()
        {
            try
            {
                var result = await context.ProductMaster.FromSql("spGetProducts").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
