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
            getdesayuno();
        }

        public async void getdesayuno()
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base +"/api/productoss/Getproductos");
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
                ViewModel.MenuDVM menuDVM = e.SelectedItem as ViewModel.MenuDVM;
                await App.Current.MainPage.Navigation.PushAsync(new Ordenar { BindingContext = e.SelectedItem });
            }
        }

        private void BtnarmaD_Clicked(object sender, EventArgs e)
        {

        }

        private void Btnbebidasc_Clicked(object sender, EventArgs e)
        {

        }
    }
}
