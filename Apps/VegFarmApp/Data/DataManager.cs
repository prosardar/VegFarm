using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegFarm.Data
{
    public class DataManager
    {
        private Dictionary<Type, object> _dataSources => new Dictionary<Type, object>();

        private VegClient _client => new VegClient();

        public DataManager()
        {

        }

        internal async Task<object> GetDataSourceAsync<T>() where T : new()
        {
            if (_dataSources.ContainsKey(typeof(T)))
            {
                return _dataSources[typeof(T)];
            }
            IEnumerable<T> newValue = await _client.GetAllObjectsAsync<T>();
            _dataSources.Add(typeof(T), newValue);
            return newValue;
                
        }
    }
}
