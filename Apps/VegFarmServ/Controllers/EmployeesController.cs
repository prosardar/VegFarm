using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VerFarm.Kernel.Model.DTO;
using VerFarm.Kernel.BL.Service;

namespace VegFarm.Controllers
{
    public class EmployeesController : ApiController
    {
        private IService<EmployeeDTO> _service { get; set; }

        public EmployeesController()
        {

        }

        public EmployeesController(IService<EmployeeDTO> service) : this()
        {
            _service = service;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return await _service.GetAll();
        }

        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            EmployeeDTO em = await _service.GetById(id);
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
            bool result = await _service.Delete(id);
            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return NotFound();
        }
    }
}
