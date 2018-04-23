using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.Data.Context
{
    public class EmployeeContextInitializer : CreateDatabaseIfNotExists<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            context.CatalogDepartment.Add(new CatalogDepartment
            {
                Name = "отдел продаж",
                EmployeeCount = 5
            });
            context.CatalogDepartment.Add(new CatalogDepartment
            {
                Name = "производственный отдел",
                EmployeeCount = 5
            });
            context.CatalogDepartment.Add(new CatalogDepartment
            {
                Name = "отдел доставки",
                EmployeeCount = 5
            });
            context.CatalogDepartment.Add(new CatalogDepartment
            {
                Name = "отдел кадров",
                EmployeeCount = 5
            });

            context.CatalogQualification.Add(new CatalogQualification
            {
                Qualification = "практикант",
                Rang = 1
            });
            context.CatalogQualification.Add(new CatalogQualification
            {
                Qualification = "инженер",
                Rang = 2
            });
            context.CatalogQualification.Add(new CatalogQualification
            {
                Qualification = "ведущий инженер",
                Rang = 3
            });

            base.Seed(context);
        }
    }
}
