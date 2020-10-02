using Ass7.Adapters;
using Ass7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ass7.Services
{
    class OpenWeatherMap
    {
        private Adapter _adapter = new Adapter();
        public async Task<Root> WeatherMap()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_adapter.WeatherMap);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Root>(stringContent);
            }
            return null;
        }
    }
}
