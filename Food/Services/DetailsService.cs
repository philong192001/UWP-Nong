using Food.Adapters;
using Food.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    class DetailsService
    {
        //service này lấy ra sản phẩm chi tiết theo id
        private Adapter _adapter = new Adapter();

        public async Task<FoodDetails> FoodDetails(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_adapter.ProductDetail(id));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FoodDetails>(stringContent);
            }
            return null;
        }
    }
}
