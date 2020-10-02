using Practical_UWP.Models;
using Practical_UWP.Services;
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

namespace Practical_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ass2 : Page
    {
        private UserServices service = new UserServices();
        public Ass2()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account(username.Text, Convert.ToInt32(password.Text));
            var list = (List<Account>)UserServices.CheckLogin();
            bool isCheck = false;
            foreach (var item in list)
            {
                if (item.username.Equals(account.username) && (item.password == account.password))
                {
                    isCheck = true;

                    break;
                }
            }
            if (isCheck)
            {
                MessageDialog mss = new MessageDialog("dang nhap thanh cong");
                await mss.ShowAsync();
                return;
            }
            MessageDialog ms = new MessageDialog("dang nhap k thanh cong");
            await ms.ShowAsync();
        }
    }
}
