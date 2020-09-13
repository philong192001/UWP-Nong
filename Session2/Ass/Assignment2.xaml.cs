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

namespace Session2.Ass
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Assignment2 : Page
    {
        public Assignment2()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string type = ((ComboBoxItem)cbTypeContact.SelectedItem).Content.ToString();
            string icon = "";
            if (type == "DEV")
            {
                icon = "EA8C";
            }
            else if (type == "BA")
            {
                icon = "EB50";
            }
            else if (type == "TESTER")
            {
                icon = "E726";
            }
            else
            {
                icon = "E72C";
            }
            Customer cus = new Customer(Name.Text, (char)(Convert.ToInt32(icon, 16)), Phone.Text, cbTypeContact.Text);// co 4 tham so thoi ma // no cu doi 5 tham so the em moi k hieu
            //Customer cus = new Customer("ddsf", 'a', "0971056231", "hjhj");
            LV.Items.Add(cus);
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            LV.Items.Remove(LV.SelectedItem);
        }
    }
}