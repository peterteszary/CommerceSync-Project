using Newtonsoft.Json;
using ProductBridge.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductBridge.Sync
{
    public class WooCommerceSync
    {
        private readonly string apiUrl;
        private readonly string apiKey;

        public WooCommerceSync(string apiUrl, string apiKey)
        {
            this.apiUrl = apiUrl;
            this.apiKey = apiKey;
        }

        public async Task SyncProducts(List<Product> products)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:"))}");

                foreach (var product in products)
                {
                    var json = JsonConvert.SerializeObject(product);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{apiUrl}/wp-json/wc/v3/products", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Failed to sync product {product.ProductName}. Status code: {response.StatusCode}");
                    }
                }
            }
        }

        public async Task SyncUsers(List<User> users)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:"))}");

                foreach (var user in users)
                {
                    var json = JsonConvert.SerializeObject(user);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{apiUrl}/wp-json/wp/v2/users", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Failed to sync user {user.UserName}. Status code: {response.StatusCode}");
                    }
                }
            }
        }
    }
}
