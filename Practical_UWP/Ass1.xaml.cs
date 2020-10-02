using Cake.Core.IO;
using Newtonsoft.Json;
using Practical_UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
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

namespace Practical_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ass1 : Page
    {
        public Ass1()
        {
            this.InitializeComponent();
            LoadJson();
            //LoadFromJsonAsync();
        }
        public void LoadJson()
        {
            string FilePath = System.IO.Path.Combine(Package.Current.InstalledLocation.Path, "Json\\employee.json");
            using (StreamReader file = File.OpenText(FilePath))
            {
                var json = file.ReadToEnd();
                Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                string contacts = result["Json\\employee.json"].ToString();
                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(contacts);
                EmpployeeList.ItemsSource = emp;
                //FileHandleService.WriteFile('D:\\C# ApTech\\T1907a\\Practical_UWP\\Json\\employee.json');
            }
        }
       
//public void LoadJson()
//{
//    using (StreamReader r = new StreamReader("C:\\Users\\Admin\\Desktop\\employee.json"))
//    {
//        string json = r.ReadToEnd();
//        List<Employee> items = JsonConvert.DeserializeObject<List<Employee>>(json);
//        dynamic array = JsonConvert.DeserializeObject(json);
//        LV.ItemsSource = items;
//    }
//}
//private static string JsonFile = "C:\\Users\\Admin\\Desktop\\employee.json";

//public static async Task<List<string>> LoadFromJsonAsync()
//{
//    string JsonString = await DeserializeFileAsync(JsonFile);
//    if (JsonString != null)
//        return (List<string>)JsonConvert.DeserializeObject(JsonString, typeof(List<string>));
//    return null;

//}

//private static async Task<string> DeserializeFileAsync(string fileName)
//{
//    try
//    {
//        StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
//        return await FileIO.ReadTextAsync(localFile);
//    }
//    catch (FileNotFoundException)
//    {
//        return null;
//    }
//}
    }
}
