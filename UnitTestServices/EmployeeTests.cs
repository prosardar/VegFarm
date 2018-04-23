using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerFarm.Kernel.BL.Implemantation;
using VerFarm.Kernel.Data.Context;
using System.Collections.Generic;
using VerFarm.Kernel.Model.DTO;

namespace UnitTestServices
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void GetAll()
        {
            var context = new EFDbContext(new EmployeeContext());
            var mapper = EmployeeMapperConfig.CreateMapper();

            var service = new EmployeeService(context, mapper);
            var t = service.GetAll();
            t.Wait();
            List<EmployeeDTO> list = t.Result as List<EmployeeDTO>;
            Assert.IsNotNull(list);
            int c = list.Count;

        }
    }
}
