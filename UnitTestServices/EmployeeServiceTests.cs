using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerFarm.Kernel.BL.Implemantation;
using System.Collections.Generic;
using VerFarm.Kernel.Model.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestServices
{
    [TestClass]
    public class EmployeeServiceTests : ServiceTest
    {
        private EmployeeService _service;

        [TestInitialize]
        public override void Start()
        {
            base.Start();
            _service = new EmployeeService(Context, Mapper);
        }

        [TestMethod]
        public void GetAll()
        {
            Task<IEnumerable<IBaseDTO>> t = _service.GetAll();
            t.Wait();
            var list = t.Result as IEnumerable<IBaseDTO>;
            Assert.IsNotNull(list);
            int c = list.Count();
            Assert.AreNotEqual(0, c);

            IBaseDTO firstDto = list.First();
            EmployeeDTO dto = firstDto as EmployeeDTO;
       
        }

        [TestMethod]
        public void Update()
        {
            EmployeeDTO newEmployee = new EmployeeDTO
            {
                Id = 1,
                FName = "WWW",
                IName = "EEE",
                OName = "FFF",
                Probation = true,
                QualificationId = 3,
                DepartmentId = 1
            };
            Task<IBaseDTO> t = _service.Update(newEmployee);
            t.Wait();
            var newDto = t.Result as EmployeeDTO;
            Assert.IsNotNull(newDto);
            int id = newDto.QualificationId;
        }

        [TestMethod]
        public void CreateAndDelete()
        {
            // Идеально Имеет место создавать тестовую бд перед выполнением, а
            // мы сдеаем два теста в одном, но так делать нельзя с идеологической точки зрения, да и не только!!!
            // они НЕ ДОЛЖНЫ зависить друг от друга и проверять каждый должен конкретный свой аспект

            EmployeeDTO newEmployee = new EmployeeDTO
            {
                FName = "asd",
                IName = "sd",
                OName = "asd",
                Probation = false,
                QualificationId = 1,
                DepartmentId = 1
            };
            Task<IBaseDTO> t = _service.Add(newEmployee);
            t.Wait();
            var newDto = t.Result as EmployeeDTO;
            Assert.IsNotNull(newDto, "Создание");

            Task<bool> t2 = _service.Delete(newDto.Id);
            t.Wait();
            bool result = t2.Result;
            Assert.IsTrue(result, "Удаление");
        }
    }
}
