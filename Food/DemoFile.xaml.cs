using Food.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Food
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoFile : Page
    {
        public DemoFile()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileHandleService.WriteFile("t1907a.txt", "xin chao tat ca cac ban");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string txt = await FileHandleService.ReadFile("t1907a.txt");
            TxtBlock.Text = txt;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "t1907a";
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                FileIO.WriteTextAsync(file, "Buoi tiep theo se thi");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
