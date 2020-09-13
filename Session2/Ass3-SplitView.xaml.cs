using Session2.Models;
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

namespace Session2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ass3_SplitView : Page
    {
        public Ass3_SplitView()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SV.IsPaneOpen = !SV.IsPaneOpen;
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            //LV.Items.Add(new MenuItem((char)(Convert.ToInt32("E80F", 16)), "List Contact"));
            //LV.Items.Add(new MenuItem((char)(Convert.ToInt32("EA4A", 16)), "Add Contact"));
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //Customer cus = new Customer(Name.Text, Phone.Text, CbxContact.Text);
            //LeVi.Items.Add(cus);
        }
    }
}
