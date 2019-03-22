using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
            string URL = string.Format("http://paraisoreal19.somee.com/api/productoss/Getproductos/"+ id.Text);
            var miArreglo = await client.GetAsync(URL);
            var result = miArreglo.Content.ReadAsStringAsync().Result;
            JObject values = JObject.Parse(result);
            var ArrData = (JArray)values["categorias"];
            var ListDesayuno =  JsonConvert.DeserializeObject<List<productos>>(result);
            
            for (int i = 0; i < ArrData.Count; i++)
            {
                ListDesayuno.Add(new productos()
                {
                    idcategoria = int.Parse(ArrData[i]["idcategoria"].ToString()),
                    nomproducto = ArrData[i]["nomproducto"].ToString()
                });
                Debug.WriteLine(ArrData[i]["nomproduto"].ToString());

            }


           //var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
         
           // ListDesayuno.ItemsSource = verproductos;

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
