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
    public sealed partial class Category : Page
    {
        private CategoryService _categoryService = new CategoryService();
        public Category()
        {
            this.InitializeComponent();
        }
        private MenuItem CatDetail { get; set; }
        private Item Detail{ get;set;}
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            MenuItem menuItem = e.Parameter as MenuItem;
            CatDetail = menuItem;
            Models.CategoryDetail catDetail = await _categoryService.CategoryDetail(CatDetail.id);
            ProductList.ItemsSource = catDetail.data.foods;
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Item detail = ProductList.SelectedItem as Item;
            MainPage.mainFrame.Navigate(typeof(ProductsDetails), detail);
        }
      
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Detail = e.Parameter as Item;
        }

        private void heart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();

            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var sqlString = "INSERT INTO Products(id,name,image,description,price) VALUES(?,?,?,?,?)";
            var stt = sQLiteConnection.Prepare(sqlString);
            stt.Bind(1, Detail.id);
            stt.Bind(2, Detail.name);
            stt.Bind(3, Detail.image);
            stt.Bind(4, Detail.description);
            stt.Bind(5, Detail.price);
            stt.Step();
            MainPage.mainFrame.Navigate(typeof(ListFavorite));
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string select = e.AddedItems[0].ToString();
            if (select.Equals("SortByName"))
            {
                Models.CategoryDetail catDetail = await _categoryService.CategoryDetail(CatDetail.id);
                ProductList.ItemsSource = catDetail.data.foods.OrderBy(P => P.name);

            }
            else
            {
                Models.CategoryDetail catDetail = await _categoryService.CategoryDetail(CatDetail.id);
                ProductList.ItemsSource = catDetail.data.foods.OrderBy(P => P.price);
            }
        }

        private async void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Item> listSearch = new List<Item>();
            Models.CategoryDetail catDetail = await _categoryService.CategoryDetail(CatDetail.id);
            var list = catDetail.data.foods;
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.name.Contains(tbSearch.Text))
                    {
                        listSearch.Add(item);
                    }
                }
               //get data
                ProductList.ItemsSource = listSearch;
            }
        }
    }
}
