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
    public class CatalogServiceTests : ServiceTest
    {
        private CatalogService _service;

        [TestInitialize]
        public override void Start()
        {
            base.Start();
            _service = new CatalogService(Context, Mapper);
        }

        [TestMethod]
        public void GetAllDepartments()
        {
            Task<IEnumerable<IBaseDTO>> t = _service.GetAll("departments");
            t.Wait();
            var list = t.Result as IEnumerable<IBaseDTO>;
            Assert.IsNotNull(list);
            int c = list.Count();
            Assert.AreNotEqual(0, c);
        }

        [TestMethod]
        public void UpdateDepartment()
        {
            CatalogDepartmentDTO dto = new CatalogDepartmentDTO
            {
                Id = 1,
                Name = "New Name"
            };
            Task<IBaseDTO> t = _service.Update("departments", dto);
            t.Wait();
            var newDto = t.Result as CatalogDepartmentDTO;
            Assert.IsNotNull(newDto);
            string name = newDto.Name;
        }

        [TestMethod]
        public void CreateAndDeleteDepartment()
        {
            // Идеально Имеет место создавать тестовую бд перед выполнением, а
            // мы сдеаем два теста в одном, но так делать нельзя с идеологической точки зрения, да и не только!!!
            // они НЕ ДОЛЖНЫ зависить друг от друга и проверять каждый должен конкретный свой аспект

            CatalogDepartmentDTO dto = new CatalogDepartmentDTO
            {
                Name = "Else one more",
                EmployeeCount = 5,
            };
            Task<IBaseDTO> t = _service.Add("departments", dto);
            t.Wait();
            var newDto = t.Result as CatalogDepartmentDTO;
            Assert.IsNotNull(newDto, "Создание");

            Task<bool> t2 = _service.Delete("departments", newDto.Id);
            t2.Wait();
            bool result = t2.Result;
            Assert.IsTrue(result, "Удаление");
        }
    }
}
