using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Model.DTO;
using VerFarm.Kernel.Data.Entity;
using AutoMapper;

namespace VerFarm.Kernel.BL.Implemantation
{
    public class EmployeeTransferService : IEmployeeTransferService
    {
        private Repository<EmployeeTransfer, EmployeeTransferDTO> _transferLogRep;

        public EmployeeTransferService(IDbContext context, IMapper mapper)
        {
            _transferLogRep = new Repository<EmployeeTransfer, EmployeeTransferDTO>(context, mapper);
        }

        public async Task<IBaseDTO> Add(IBaseDTO dto)
        {
            return await _transferLogRep.Add(dto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _transferLogRep.Delete(id);
        }

        public async Task<IEnumerable<IBaseDTO>> GetAll()
        {
            return await _transferLogRep.GetAll();
        }

        public async Task<IBaseDTO> GetById(int id)
        {
            return await _transferLogRep.GetById(id);
        }

        public async Task<IBaseDTO> Update(IBaseDTO dto)
        {
            return await _transferLogRep.Update(dto);
        }
    }
}
