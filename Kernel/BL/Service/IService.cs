﻿using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Service
{
    public interface IService<TDto> : IBaseService where TDto : IBaseDTO
    {
       
    }
}