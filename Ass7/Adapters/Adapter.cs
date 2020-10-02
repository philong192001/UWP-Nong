
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass7.Adapters
{
    class Adapter
    {
        private string baseURL = "http://api.openweathermap.org/data/2.5/weather";
        public string WeatherMap
        {
            get => String.Format(baseURL + "?q=hanoi,vn&appid=09a71427c59d38d6a34f89b47d75975c&units=metric");
        }
    }
}
