using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IronRebelB2B.Models;
using Newtonsoft.Json;

namespace IronRebelB2B.Services
{
    public class CustomerService : BaseService
    {
        private readonly string _url;

        public CustomerService(ShopifyCredentials creds) : base(creds)
        {
            _url = base.GetUrl();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            string resource = "/admin/customers.json";

            string uri = base.GetUrl() + resource;

            using (HttpClient httpClient = new HttpClient(base.GetAuthHandle()))
            {
                return JsonConvert.DeserializeObject<List<Customer>>(await httpClient.GetStringAsync(uri));
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            string resource = $@"/admin/customers.json?ids={id}";

            string uri = base.GetUrl() + resource;

            using (HttpClient httpClient = new HttpClient(base.GetAuthHandle()))
            {
                return JsonConvert.DeserializeObject<Customer>(await httpClient.GetStringAsync(uri));
            }
        }

        public async Task<List<Customer>> GetByIdsAsync(List<int> ids)
        {
            string resource = $@"/admin/customers.json?ids={string.Join(",", ids)}";

            string uri = base.GetUrl() + resource;

            using (HttpClient httpClient = new HttpClient(base.GetAuthHandle()))
            {
                return JsonConvert.DeserializeObject<List<Customer>>(await httpClient.GetStringAsync(uri));
            }
        }
    }
}
