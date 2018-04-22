using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VerFarm.Kernel.Model;
using VerFarm.Kernel.Model.Service;

namespace VegFarm.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeeService Service { get; set; }

        public EmployeesController(IEmployeeService service)
        {
            Service = service;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return await Service.GetAllEmployeesAsync();
        }

        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            EmployeeDTO em = await Service.GetEmployeeAsync(id);
            if (em == null)
            {
                return NotFound();
            }
            return Ok(em);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]EmployeeDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }


            return Ok(item);
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Update(int id, [FromBody]EmployeeDTO item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

          return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            int count = await Service.DeleteAsync(id);
            if (count == 0)
            {
                return NotFound();
            }            

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
