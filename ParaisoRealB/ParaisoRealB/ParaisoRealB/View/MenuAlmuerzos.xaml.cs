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
    public partial class MenuAlmuerzos : ContentPage
    {
        public MenuAlmuerzos()
        {
            InitializeComponent();
            //horaAlmuerzo();

        }

        //public async void horaAlmuerzo()
        //{
        //    DateTime hora = DateTime.Now;
        //    DateTime horamax = new DateTime(2019, 05, 01, 13, 00, 00);

        //    if (hora.TimeOfDay >= horamax.TimeOfDay)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Mensaje", "Almuerzos disponibles hasta las 1:00 PM", "Ok");
        //        await App.Current.MainPage.Navigation.PopAsync();
        //    }

        //}

        public async void Btnarmarcombo_Clicked(object sender, EventArgs e)
        {
            indicatora.IsRunning = true;
            try
            {
                var client = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
                var miArreglo = await client.GetStringAsync(URL);
                var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
                var nuevalista = verproductos.Where(a => a.idcategoria == 2 && a.idestado > 0);
                ListAlmuerzo.ItemsSource = nuevalista;

                btnarmarcombo.IsEnabled = true;
            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                btnarmarcombo.IsEnabled = true;
                indicatora.IsRunning = false;
                return;
            }

            indicatora.IsRunning = false;

        }

        public async void BtnCombos_Clicked(object sender, EventArgs e)
        {
            indicatora.IsRunning = true;
            try
            {
                var client = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
                var miArreglo = await client.GetStringAsync(URL);
                var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
                var nuevalista = verproductos.Where(a => a.idcategoria == 3 && a.idestado > 0);
                ListAlmuerzo.ItemsSource = nuevalista;

                btnCombos.IsEnabled = true;

            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                btnCombos.IsEnabled = true;
                indicatora.IsRunning = false;
                return;
            }

            indicatora.IsRunning = false;
        }
        public async void Btnbebidaf_Clicked(object sender, EventArgs e)
        {
            indicatora.IsRunning = true;
            try
            {

                var client = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
                var miArreglo = await client.GetStringAsync(URL);
                var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
                var nuevalista = verproductos.Where(a => a.idcategoria == 5 && a.idestado > 0);
                ListAlmuerzo.ItemsSource = nuevalista;

                btnbebidaf.IsEnabled = true;
            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                btnbebidaf.IsEnabled = true;
                indicatora.IsRunning = false;
                return;
            }

            indicatora.IsRunning = false;



        }

        public async void ListAlmuerzo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Ordenar { BindingContext = e.SelectedItem });
            }


        }


    }
}
