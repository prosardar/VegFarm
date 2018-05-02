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
    public class EmployeeTransferController : BaseController
    {
        public IEmployeeTransferService _service => (IEmployeeTransferService) Service;

        public EmployeeTransferController()
        {

        }

        public EmployeeTransferController(IEmployeeTransferService service) : base(service)
        {
        }
    }
}
