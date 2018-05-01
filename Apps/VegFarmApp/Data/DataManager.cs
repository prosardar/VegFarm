using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Data
{
    public class DataManager
    {
        private Dictionary<Type, ICachedData> _dataSources = new Dictionary<Type, ICachedData>();

        private VegClient _client = new VegClient();

        public DataManager()
        {
            _client.RegisterQuery(typeof(EmployeeDTO), "api/employees/");
            _client.RegisterQuery(typeof(CatalogDepartmentDTO), "api/catalog?name=departments");
            _client.RegisterQuery(typeof(CatalogQualificationDTO), "api/catalog?name=qualifications");
        }

        internal async Task<ICachedData> GetDataSourceAsync<TDto>() where TDto : BaseDTO
        {
            if (_dataSources.ContainsKey(typeof(TDto)))
            {
                return (CacheCollection<TDto>)_dataSources[typeof(TDto)];
            }
            IEnumerable<TDto> newValue = await _client.GetAllObjectsAsync<TDto>();
            ICachedData cache = new CacheCollection<TDto>(newValue);
            _dataSources.Add(typeof(TDto), cache);
            return cache;
        }

        internal void Delete(Type dtoType, int id)
        {
            // при удалении на сервере удалить из внутреннего кеша
            Task<HttpStatusCode> t = _client.DeleteAsync(dtoType, id);
            t.ContinueWith(td =>
            {
                if (td.Result != HttpStatusCode.Accepted)
                {
                    return;
                }
                if (_dataSources.ContainsKey(dtoType))
                {
                    ICachedData items = _dataSources[dtoType];
                    items.Delete(id);
                }
            });
        }

        internal void Update(BaseDTO dto)
        {
            // при изменении на сервере, изменить в кеше
            Task<BaseDTO> t = _client.UpdateAsync(dto);
            t.ContinueWith(td =>
            {
                BaseDTO dtoFromServer = td.Result as BaseDTO;
                if (IfErrorShowMessage(dtoFromServer))
                {
                    return;
                }
                if (_dataSources.ContainsKey(dto.GetType()))
                {
                    ICachedData items = _dataSources[dto.GetType()];
                    items.Update(dto);
                }
            });
        }

        internal void Create(BaseDTO dto)
        {
            Task<BaseDTO> t = _client.CreateObjectAsync(dto);
            t.ContinueWith(td =>
            {
                BaseDTO dtoFromServer = td.Result as BaseDTO;
                if (IfErrorShowMessage(dtoFromServer))
                {
                    return;
                }
                if (_dataSources.ContainsKey(dto.GetType()))
                {
                    ICachedData items = _dataSources[dto.GetType()];
                    items.Add(dto);
                }
                else
                {
                    ICachedData cache = new CacheCollection<BaseDTO>();
                    cache.Add(td.Result);
                    _dataSources.Add(dto.GetType(), cache);
                }
            });
        }

        private bool IfErrorShowMessage(BaseDTO dto)
        {
            if (dto == null)
            {
                return true;
            }
            if (dto.IsError)
            {
                XtraMessageBox.Show(dto.Message, "Ошибка", MessageBoxButtons.OK);
                return true;
            }
            return false;
        }
    }
}
