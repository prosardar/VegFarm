using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Data.Entity;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Implemantation
{
    public class EmployeeMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeTransfer, EmployeeTransferDTO>();                
                cfg.CreateMap<CatalogDepartment, CatalogDepartmentDTO>();
                cfg.CreateMap<CatalogQualification, CatalogQualificationDTO>();
                cfg.CreateMap<ChangeLog, ChangeLogDTO>();
            });
            return config.CreateMapper();
        }
    }
}
