﻿using Newtonsoft.Json;
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

        }

        public async void Btnarmarcombo_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base +"/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 2 && a.existencia > 0);
            ListAlmuerzo.ItemsSource = nuevalista;

        }

        public async void BtnCombos_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 3 && a.existencia > 0);
            ListAlmuerzo.ItemsSource = nuevalista;

        }

        public async void Btnbebidaf_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 5 && a.existencia > 0);
            ListAlmuerzo.ItemsSource = nuevalista;
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
