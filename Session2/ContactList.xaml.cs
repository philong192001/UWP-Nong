﻿using System;
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
    public sealed partial class ContactList : Page
    {
        public ContactList()
        {
            this.InitializeComponent();//sinh ra giao dien
            //dieu khien giao dien tu ben UI
            GV.ItemsSource = new ViewModels.ViewModel().Mails;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Ass3_SplitView.contentFrame.Navigate(typeof(AddContact));
        }
    }
}