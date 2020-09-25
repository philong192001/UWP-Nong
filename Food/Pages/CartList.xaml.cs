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
    public sealed partial class CartList : Page
    {
        public CartList()
        {
            this.InitializeComponent();
            getCartList();
        }
        public void getCartList()
        {
            Cart cart = new Cart();
            List<CartItem> items = cart.GetCarts();
            CartItems.ItemsSource = items;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            CartItem item = textBox.Tag as CartItem;
            Cart cart = new Cart();
            if (cart.UpdateQty(item, Convert.ToInt32(textBox.Text)))
            {
                List<CartItem> items = cart.GetCarts();
                CartItems.ItemsSource = items;
            }
        }
        private void Delete_Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
          
        }      
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog ms = new ContentDialog()
            {
                Title = "Thông Báo",
                Content = "Bạn có muốn xóa danh sách sản phẩm",
                PrimaryButtonText = "OK",
                CloseButtonText = "Close"

            };
            ContentDialogResult result = await ms.ShowAsync();


            if (result == ContentDialogResult.Primary)
            {
                Cart service = new Cart();
                service.ClearCart();
                getCartList();
            }
        }

        private async void FontIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var cart = CartItems.SelectedItem as CartItem;

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
                Cart service = new Cart();
                service.DeleteItem(cart);
                getCartList();
            }
        }

        private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
