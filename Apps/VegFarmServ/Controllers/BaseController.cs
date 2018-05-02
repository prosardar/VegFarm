using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Controllers
{
    public class BaseController : ApiController
    {
        public IService<IBaseDTO> Service;

        public BaseController()
        {

        }

        public BaseController(IService<IBaseDTO> service)
        {
            Service = service;
        }

        public async Task<IEnumerable<IBaseDTO>> Get()
        {
            return await Service.GetAll();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            IBaseDTO dto = await Service.GetById(id);
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
            IBaseDTO dto = await Service.Add(item);
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
            IBaseDTO dto = await Service.Update(item);
            if (dto == null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            return Ok(dto);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            bool result = await Service.Delete(id);
            if (result)
            {
                return StatusCode(HttpStatusCode.Accepted);
            }
            return StatusCode(HttpStatusCode.NotAcceptable);
        }
    }
}
