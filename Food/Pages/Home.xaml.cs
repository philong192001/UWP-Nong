using Food.Models;
using Food.Services;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Food.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        private ProductService _productService = new ProductService();
        public Home()
        {
            this.InitializeComponent();
            TodaySpecial();
        }
        public async void TodaySpecial()
        {
            ListItem productList = await _productService.TodaySpecial();
            if (productList != null)
            {
                ProductList.ItemsSource = productList.data;
            }
        }

        private void ProductList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Item detail = ProductList.SelectedItem as Item;
            MainPage.mainFrame.Navigate(typeof(ProductsDetails), detail);
        }

        private async void tbSearch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            List<Item> listSearch = new List<Item>();
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ListItem productList = await _productService.TodaySpecial();
                if (productList != null)
                {
                    foreach (var item in productList.data)
                    {
                        if (item.name.Contains(tbSearch.Text))
                        {
                            listSearch.Add(item);
                        }
                    }
                    ProductList.ItemsSource = listSearch;
                }
            }
        }

        private async void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Item> listSearch = new List<Item>();

            ListItem productList = await _productService.TodaySpecial();
            if (productList != null)
            {
                foreach (var item in productList.data)
                {
                    if (item.name.Contains(tbSearch.Text))
                    {
                        listSearch.Add(item);
                    }
                }
                ProductList.ItemsSource = listSearch;
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string select = e.AddedItems[0].ToString();
            if (select.Equals("SortByName"))
            {
                ListItem productList = await _productService.TodaySpecial();
                var ProductSortByPrice = productList.data.OrderBy(P => P.name);
                ProductList.ItemsSource = ProductSortByPrice;
            }
            else
            {
                ListItem productList = await _productService.TodaySpecial();
                var ProductSortByPrice = productList.data.OrderBy(P => P.price);
                ProductList.ItemsSource = ProductSortByPrice;
            }
        }
    }
}
