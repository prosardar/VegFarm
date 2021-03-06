﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using VerFarm.Kernel.Model.DTO;
using VerFarm.Kernel.BL.Service;
using System.Linq;

namespace VegFarm.Controllers
{
    public class EmployeesController : BaseController
    {
        private IEmployeeService _service => (IEmployeeService)Service;

        public EmployeesController()
        {

        }

        public EmployeesController(IEmployeeService service) : base(service)
        {
        }
    }
}
