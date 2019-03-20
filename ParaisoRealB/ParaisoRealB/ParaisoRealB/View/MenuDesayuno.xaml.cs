using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDesayuno : ContentPage
    {
     

        public MenuDesayuno()
        {
            InitializeComponent();
            getdesayuno();
        }

        public async void getdesayuno()
        {
         
            
           



            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            ListDesayuno.ItemsSource = verproductos;

        }

        public async void ListDesayuno_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Ordenar { BindingContext = e.SelectedItem });
            }
        }
    }
}
