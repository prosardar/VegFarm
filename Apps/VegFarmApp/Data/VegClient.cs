using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Data
{
    public class VegClient
    {
        private Dictionary<Type, string> _requestQueryDic = new Dictionary<Type, string>();
        private HttpClient _client = new HttpClient();

        public VegClient()
        {
            _client.BaseAddress = new Uri(Properties.Settings.Default.AddressServer);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _requestQueryDic[typeof(EmployeeDTO)] = "api/employees/";
        }

        private string GetRequestString(Type typeOfResponseData)
        {
            if (_requestQueryDic.ContainsKey(typeOfResponseData))
            {
                return _requestQueryDic[typeOfResponseData];
            }

            throw new ApplicationException("Не найдена строка запроса для типа " + typeOfResponseData.Name);
        }

        internal async Task<IEnumerable<T>> GetAllObjectsAsync<T>()
        {
            string request = GetRequestString(typeof(T));
            return await GetAsync<IEnumerable<T>>(request);
        }

        internal async Task<T> GetObjectAsync<T>()
        {
            string request = GetRequestString(typeof(T));
            return await GetAsync<T>(request);
        }

        internal async Task<T> CreateObjectAsync<T>(T newObject)
        {
            string request = GetRequestString(typeof(T));
            HttpResponseMessage response = await _client.PostAsJsonAsync(request, newObject);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        private async Task<T> GetAsync<T>(string request)
        {
            HttpResponseMessage response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        internal async Task<T> UpdateAsync<T>(T newObject) where T : DTOBase
        {
            string request = GetRequestString(typeof(T));
            HttpResponseMessage response = await _client.PutAsJsonAsync(Path.Combine(request, $"{newObject.Id}"), newObject);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        internal async Task<HttpStatusCode> DeleteAsync<T>(int id)
        {
            string request = GetRequestString(typeof(T));
            HttpResponseMessage response = await _client.DeleteAsync(Path.Combine(request, $"{id}"));
            return response.StatusCode;
        }
    }
}
