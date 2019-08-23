using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCoreSPAPI.Models;
using EFCoreSPAPI.Services;
namespace EFCoreSPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductMasterService serv;
        public ProductAPIController(IProductMasterService serv)
        {
            this.serv = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = serv.GetAsync().Result;
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(ProductMaster product)
        {
            try
            {
                var res = serv.CreateAsync(product).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}