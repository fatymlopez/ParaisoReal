﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParaisoRealB.Model.Modeldb;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDesayuno : ContentPage
    {

        public MenuDesayuno()
        {
            InitializeComponent();

            horasss();

        }

        public async void horasss()
        {
            DateTime hora = DateTime.Now;
            DateTime horamax = new DateTime(2019, 05, 01, 10, 00, 00);

            if (hora.TimeOfDay >= horamax.TimeOfDay)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Desayunos disponibles de 6:00 AM a 10:00 AM", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }

        }

        public async void BtnarmaD_Clicked(object sender, EventArgs e)
        {
            indicatord.IsRunning = true;
            try
            {
                var client = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
                var miArreglo = await client.GetStringAsync(URL);
                var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
                var nuevalista = verproductos.Where(a => a.idcategoria == 1 && a.idestado > 0);
                ListDesayuno.ItemsSource = nuevalista;

                btnarmaD.IsEnabled = true;
            }



            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                btnarmaD.IsEnabled = true;
                indicatord.IsRunning = false;
                return;
            }

            indicatord.IsRunning = false;
        }

        public async void Btnbebidasc_Clicked(object sender, EventArgs e)
        {
            indicatord.IsRunning = true;
            try
            {
                var client = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
                var miArreglo = await client.GetStringAsync(URL);
                var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
                var nuevalista = verproductos.Where(a => a.idcategoria == 6 && a.idestado > 0);
                ListDesayuno.ItemsSource = nuevalista;
                btnbebidasc.IsEnabled = true;
            }



            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "No hay conexion a internet", "Ok");
                btnbebidasc.IsEnabled = true;
                indicatord.IsRunning = false;
                return;
            }

            indicatord.IsRunning = false;
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
