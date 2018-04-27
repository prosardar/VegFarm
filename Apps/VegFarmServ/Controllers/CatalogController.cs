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
    public class CatalogController : ApiController
    {
        private ICatalogService<IBaseDTO> _service { get; set; }

        public CatalogController()
        {

        }

        public CatalogController(ICatalogService<IBaseDTO> service) : this()
        {
            _service = service;
        }

        public async Task<IEnumerable<IBaseDTO>> GetAll(string name)
        {
            return await _service.GetAll(name);
        }

        public async Task<IHttpActionResult> Get(string name, int id)
        {
            IBaseDTO dto = await _service.GetById(name, id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(string name, [FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            IBaseDTO dto = await _service.Add(name, item);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Update(string name, [FromBody]IBaseDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            IBaseDTO dto = await _service.Update(name, item);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(string name, int id)
        {
            bool result = await _service.Delete(name, id);
            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return NotFound();
        }
    }
}
