using BookShopping.WebApp.Repository.IRepository;
using Newtonsoft.Json;
using System.Text;

namespace BookShopping.WebApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClient;
        public Repository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        //Address -- url  // letter -- obj,data
        public async Task<bool> CreateAsync(string url, T ObjToCreate)
        {
            //Address 
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            //val letter -- empty
            if(ObjToCreate != null)
            {
                //seal - ubba dabba --  serialize obj, data -- serailize - Json 
                request.Content = new StringContent(JsonConvert.SerializeObject(ObjToCreate), Encoding.UTF8,"application/json");
            }
            //Postman 
            var client = _httpClient.CreateClient();
            //Postman -- url + obj
            HttpResponseMessage response = await client.SendAsync(request);
            //response - acknowlgment -- call 
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                //letter reviced
                return true;
            else
                //letter golmaal
                return false;
        }

        public async Task<bool> DeleteAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + id.ToString());
            var client = _httpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _httpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            return null;
        }

        public async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,url + id.ToString());
            var client = _httpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            if(objToUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToUpdate),Encoding.UTF8, "application/json");
            }
            var client = _httpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
