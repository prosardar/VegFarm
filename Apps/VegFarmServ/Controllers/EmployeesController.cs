using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using VerFarm.Kernel.Model.DTO;
using VerFarm.Kernel.BL.Service;
using System.Linq;

namespace VegFarm.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeeService _service { get; set; }

        public EmployeesController()
        {

        }

        public EmployeesController(IEmployeeService service) : this()
        {
            _service = service;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            IEnumerable<IBaseDTO> ems = await _service.GetAll();
            return ems.Cast<EmployeeDTO>();
        }

        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            EmployeeDTO dto = (EmployeeDTO)await _service.GetById(id);
            if (dto == null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            EmployeeDTO dto = (EmployeeDTO)await _service.Add(item);
            if (dto == null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            return Ok(dto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            IBaseDTO dto = await _service.Update(item);
            if (dto == null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            return Ok(dto);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            bool result = await _service.Delete(id);
            if (result)
            {
                return StatusCode(HttpStatusCode.Accepted);
            }
            return StatusCode(HttpStatusCode.NotAcceptable);
        }
    }
}
