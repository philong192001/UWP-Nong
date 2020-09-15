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

namespace Session2.Ass.Ass3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Assignment3 : Page
    {
        public static Frame contentFrame;
        public Assignment3()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SV.IsPaneOpen = !SV.IsPaneOpen;
        }
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("E80F", 16)), "Home", "home"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("EBDB", 16)), "List Contact", "list_contact"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("ED15", 16)), "Add Contact", "add_contact"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("E902", 16)), "List Customer", "list_customer"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("EA8C", 16)), "Add Customer", "add_customer"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("EDB3", 16)), "List Mail", "list_mail"));
            LV.Items.Add(new MenuItem((char)(Convert.ToInt32("EB7E", 16)), "Add Mail", "add_mail"));
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuItem selected = (MenuItem)LV.SelectedItem;
            if (selected.Dest.Equals("home"))
            {
                FrContent.Navigate(typeof(Home));
            }
            else if (selected.Dest.Equals("list_contact"))
            {
                FrContent.Navigate(typeof(ContactList));
            }
            else if (selected.Dest.Equals("add_contact"))
            {
                FrContent.Navigate(typeof(AddContact));
            }
            else if (selected.Dest.Equals("list_customer"))
            {
                FrContent.Navigate(typeof(CustomerList));
            }
            else if (selected.Dest.Equals("add_customer"))
            {
                FrContent.Navigate(typeof(AddCustomer));
            }
            else if (selected.Dest.Equals("list_mail"))
            {
                FrContent.Navigate(typeof(MailList));
            }
            else if (selected.Dest.Equals("add_mail"))
            {
                FrContent.Navigate(typeof(AddMail));
            }


        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame = FrContent;
            FrContent.Navigate(typeof(Home));
        }
    }
}
