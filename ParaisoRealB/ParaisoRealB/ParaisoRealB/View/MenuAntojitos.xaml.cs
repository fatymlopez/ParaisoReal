using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
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
    public partial class MenuAntojitos : ContentPage
    {
        public MenuAntojitos()
        {
            InitializeComponent();
            HoraAntojito();
        }

        public async void HoraAntojito()
        {
            DateTime hora = DateTime.Now;
            DateTime horamax = new DateTime(2019, 05, 01, 15, 00, 00);

            if (hora.TimeOfDay >= horamax.TimeOfDay)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Desayunos disponibles hasta las 3:30 PM", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }

        }

        public async void BtnAntojitos_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 4 && a.idestado > 0);
            ListAntojitos.ItemsSource = nuevalista;
        }

        public async void Btnbebidasf_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 5 && a.idestado > 0);
            ListAntojitos.ItemsSource = nuevalista;
        }

        public async void Btnbebidac_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 6 && a.idestado > 0);
            ListAntojitos.ItemsSource = nuevalista;
        }


        public async void ListAntojitos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Ordenar { BindingContext = e.SelectedItem });
            }

        }
    }
}
