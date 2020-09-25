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
using Windows.System;
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
    public sealed partial class ProductsDetails : Page
    {
        private DetailsService _Service = new DetailsService(); // goi sai service rôi
        public ProductsDetails()
        {
            this.InitializeComponent();
            //GetMenu();
        }
        private Item Detail
        {
            get;
            set;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Detail = e.Parameter as Item;
        }

   

        private void ButtonBack123_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void BtnLike_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FavoriteService.InsertProduct(Detail);
            MainPage.mainFrame.Navigate(typeof(ListFavorite));
        }

        private void BtnOrder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CartItem item = new CartItem(Detail.id, Detail.name, Detail.image, Detail.price, Convert.ToInt32(Qty.Text));
            Cart cart = new Cart();
            cart.AddToCart(item);      
        }

        private void Qty_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9) & (e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9))
            {
                e.Handled = true;
            }
        }

        private void Qty_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {

        }

        private void Qty_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
