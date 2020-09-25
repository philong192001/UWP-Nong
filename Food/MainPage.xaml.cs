using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Food.Models;
using Food.Pages;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Food
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static List<Item> FavoriteProduct = new List<Item>();
        //public static List<Cart> ListCart = new List<Cart>();
        private readonly string stringUrl = String.Format("https://foodgroup.herokuapp.com/api/menu");

        public static Frame mainFrame;
        public MainPage()
        {
            this.InitializeComponent();
            GetMenu();
            mainFrame = MF;
            Cart cart = new Cart();
            List<CartItem> cartItems = cart.GetCarts();
            CartNumber.Text = cartItems.Count.ToString();
            CartNumber.Opacity = cartItems.Count > 0 ? 1 : 0;
        }
        public async void GetMenu()
        {
            HttpClient httpClient = new HttpClient();//shipper
            var response = await httpClient.GetAsync(stringUrl);
            //khong dung await se k co du lieu

            //check xem API co dung hay khong
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                Menu menu = JsonConvert.DeserializeObject<Menu>(stringContent);
                MN.ItemsSource = menu.data;
            }
        }

        private void MF_Loaded(object sender, RoutedEventArgs e)
        {

            MF.Navigate(typeof(Pages.Home));
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuItem menuItem = MN.SelectedItem as MenuItem;
            MF.Navigate(typeof(Category), menuItem);
            Console.WriteLine(e.ToString());
        }
        private void btnFavorite_Click(object sender, RoutedEventArgs e)
        {
            MF.Navigate(typeof(ListFavorite), FavoriteProduct);// chỗ này nè
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MF.Navigate(typeof(Home));
        }

        private void Alert_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MF.Navigate(typeof(Home));
        }

        private void Home_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MF.Navigate(typeof(Home));
        }

        private void Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MF.Navigate(typeof(ListFavorite));
        }

        private void ListOrder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MF.Navigate(typeof(CartList));
        }
    }
}
