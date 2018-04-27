using System;
using AutoMapper;
using VerFarm.Kernel.BL.Implemantation;
using VerFarm.Kernel.Data.Context;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Entity;
using VerFarm.Kernel.Model.DTO;

namespace UnitTestServices
{
    public class ServiceTest
    {
        public EFDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public virtual void Start()
        {
            Context = new EFDbContext(new EmployeeContext());
            Mapper = EmployeeMapperConfig.CreateMapper();
        }
    }
}