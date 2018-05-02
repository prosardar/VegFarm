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
    public class AuditController : BaseController
    {
        public IAuditService _service => (IAuditService)Service;

        public AuditController()
        {

        }

        public AuditController(IAuditService service) : base(service)
        {
        }
    }
}
