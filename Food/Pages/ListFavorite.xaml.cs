using Food.Adapters;
using Food.Models;
using Food.Services;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class ListFavorite : Page
    {
        public ListFavorite()
        {
            this.InitializeComponent();
            GetFavourite();
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
        private void GetFavourite()
        {
            ProductList.ItemsSource = FavoriteService.GetFavourite();
        }

        private async void Delete_Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //MessageDialog ms = new MessageDialog("ee");
            //await   ms.ShowAsync();
            Item product = ProductList.SelectedItem as Item;
            ContentDialog ms = new ContentDialog()
            {
                Title = "Thông Báo",
                Content = "Bạn có muốn xóa sản phẩm khỏi danh sách",
                PrimaryButtonText = "OK",
                CloseButtonText = "Close"

            };
            ContentDialogResult result = await ms.ShowAsync();


            if (result == ContentDialogResult.Primary)
            {
                FavoriteService.deleteProduct(product.id);
                GetFavourite();
            }
            else
            {
                ContentDialog mc = new ContentDialog()
                {
                    Title = "Thông Báo : DELETE FAILED",
                };
            }
        }
    
    }
}
