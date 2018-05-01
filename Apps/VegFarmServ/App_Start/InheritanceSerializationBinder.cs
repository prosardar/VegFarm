using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.App_Start
{
    public class InheritanceSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {

            switch (typeName)
            {
                case "VerFarm.Kernel.Model.DTOs.EmployeeDTO":
                    return typeof(EmployeeDTO);
                default:
                    return base.BindToType(assemblyName, typeName);
            }
        }
    }
}
