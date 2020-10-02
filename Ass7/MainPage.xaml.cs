using Ass7.Adapters;
using Ass7.Models;
using Ass7.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ass7
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Root root;
        private OpenWeatherMap _openWeatherMap = new OpenWeatherMap();
        //private readonly string stringUrl = String.Format("http://api.openweathermap.org/data/2.5/weather?q=hanoi,vn&appid=09a71427c59d38d6a34f89b47d75975c&units=metric");
        public MainPage()
        {
            this.InitializeComponent();
            GetWeather();
        }
        public async void GetWeather()
        {
            //HttpClient httpClient = new HttpClient();//shipper
            //var response = await httpClient.GetAsync(stringUrl);
            ////khong dung await se k co du lieu

            ////check xem API co dung hay khong
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var stringContent = await response.Content.ReadAsStringAsync();
            //    Root menu = JsonConvert.DeserializeObject<Root>(stringContent);
            //    LV.ItemsSource = menu.weather;
            //}
            root = await _openWeatherMap.WeatherMap();       
            
        }
    }
}
