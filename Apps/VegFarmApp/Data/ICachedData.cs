using System;
using System.Collections.Generic;
using VegFarm.Model;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Data
{
    internal interface ICachedData
    {
        void Delete(int id);
        void Update(IBaseDTO dto);
        void Add(IBaseDTO dto);
    }
}