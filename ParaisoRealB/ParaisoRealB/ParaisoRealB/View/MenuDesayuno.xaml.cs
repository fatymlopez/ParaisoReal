using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParaisoRealB.Model.Modeldb;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;

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
            var nuevalista = verproductos.Where(a => a.idcategoria == 1 && a.existencia > 0);
            ListDesayuno.ItemsSource = nuevalista;


        }

        public async void ListDesayuno_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Ordenar { BindingContext = e.SelectedItem });
            }
        }

        public void Btnsumar_Clicked(object sender, System.EventArgs e)
        {
       
            var nueva = new List<productos>();
            var Lista = nueva.Sum(b => b.precio = 0);
            foreach (var productos in nueva)
            {
                Lista++;

            }
            txtTotal.Text = Lista.ToString();





        }



    }
}
