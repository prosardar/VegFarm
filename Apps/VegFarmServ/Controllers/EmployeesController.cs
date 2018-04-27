﻿using System;
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
        private IEmployeeService _service { get; set; }

        public EmployeesController()
        {
           
        }

        public EmployeesController(IEmployeeService service) : this()
        {
            _service = service;
        }

        public async Task<IEnumerable<IBaseDTO>> GetAllEmployees()
        {
            return await _service.GetAll();
        }

        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            IBaseDTO dto = await _service.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            IBaseDTO dto = await _service.Add(item);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Update(int id, [FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            IBaseDTO dto = await _service.Update(item);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
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
