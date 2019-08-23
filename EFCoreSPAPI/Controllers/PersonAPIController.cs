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
    public class PersonAPIController : ControllerBase
    {
        private readonly IPersonService service;
        public PersonAPIController(IPersonService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(PersonTableType person)
        {
            try
            {
                var res = service.InsertPerson(person);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}