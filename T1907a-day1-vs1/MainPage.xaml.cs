using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T1907a_day1_vs1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += Grid_Loaded;
        }
        private void test(object sender, RightTappedRoutedEventArgs e)
        {
            Process.Start(e.Handled.ToString());      
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tx2.Text = tx1.Inlines.ToString();

        }

        //private void TextBlock_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        //{
        //    TextBlock txbl = sender as TextBlock;
        //    txbl.Text = " phi van long";
        //}


    }
}
