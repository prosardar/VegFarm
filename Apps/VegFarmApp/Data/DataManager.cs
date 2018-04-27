using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Data
{
    public class DataManager
    {
        private Dictionary<Type, object> _dataSources = new Dictionary<Type, object>();

        private VegClient _client = new VegClient();

        public DataManager()
        {
            _client.RegisterQuery(typeof(EmployeeDTO), "api/employees/");
            _client.RegisterQuery(typeof(CatalogDepartmentDTO), "api/catalog?name=departments");
            _client.RegisterQuery(typeof(CatalogQualificationDTO), "api/catalog?name=qualifications");
        }

        internal async Task<IEnumerable<T>> GetDataSourceAsync<T>()
        {
            if (_dataSources.ContainsKey(typeof(T)))
            {
                return (IEnumerable<T>)_dataSources[typeof(T)];
            }
            IEnumerable<T> newValue = await _client.GetAllObjectsAsync<T>();
            _dataSources.Add(typeof(T), newValue);
            return newValue;
        }

        internal void Delete<T>(T item)
        {
            // при удалении на сервере удалить из внутреннего кеша
            Task t = _client.DeleteAsync<T>(1);

        }
    }
}
