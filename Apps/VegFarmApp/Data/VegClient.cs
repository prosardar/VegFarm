using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        private JsonMediaTypeFormatter _formatter;

        public VegClient()
        {
            _client.BaseAddress = new Uri(Properties.Settings.Default.AddressServer);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = { TypeNameHandling = TypeNameHandling.Objects }
            };
        }

        public void RegisterQuery(Type dtoType, string query)
        {
            _requestQueryDic[dtoType] = query;
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

        //internal async Task<T> CreateObjectAsync<T>(T newObject)
        //{
        //    string request = GetRequestString(typeof(T));
        //    HttpResponseMessage response = await _client.PostAsJsonAsync(request, newObject);
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsAsync<T>();
        //}

        internal async Task<T> GetAsync<T>(string request)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        internal async Task<T> CreateObjectAsync<T>(T dto) where T : BaseDTO
        {
            try
            {
                string request = GetRequestString(dto.GetType());
                HttpResponseMessage response = await _client.PostAsync(request, dto, _formatter);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        internal async Task<T> UpdateAsync<T>(T dto) where T : BaseDTO
        {
            try
            {
                string request = GetRequestString(dto.GetType());
                HttpResponseMessage response = await _client.PutAsync(request, dto, _formatter);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        internal async Task<HttpStatusCode> DeleteAsync(Type type, int id)
        {
            string request = GetRequestString(type);
            HttpResponseMessage response = await _client.DeleteAsync(Path.Combine(request, $"{id}"));
            return response.StatusCode;
        }
    }
}
