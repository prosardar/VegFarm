using System;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public interface IViewModel
    {
        int DtoId { get; }

        Type DtoType { get; }

        IBaseDTO Dto { get; }

        StateViewModel State { get; set; }        
    }
}