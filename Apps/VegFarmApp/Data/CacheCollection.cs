using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegFarm.Model;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Data
{
    public class CacheCollection<TDto> : ICachedData, IEnumerable<TDto> where TDto : IBaseDTO
    {
        private List<TDto> _values;

        public CacheCollection()
        {
            _values = new List<TDto>();
        }

        public CacheCollection(IEnumerable<TDto> values)
        {
            _values = values.ToList();
        }

        public void Delete(int id)
        {
            TDto item = _values.SingleOrDefault(v => v.Id == id);
            _values.Remove(item);
        }      

        public void Update(IBaseDTO dto)
        {
            TDto item = _values.SingleOrDefault(v => v.Id == dto.Id);
            if (item == null)
            {
                return;
            }
            int index = _values.IndexOf(item);
            _values[index] = (TDto)dto;
        }

        public IEnumerator<TDto> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(IBaseDTO dto)
        {
            _values.Add((TDto)dto);
        }
    }
}
