using ParaisoRealB.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using ParaisoRealB.ViewModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPpal : ContentPage
    {       
        public MenuPpal()
        {
            InitializeComponent();
             
        }
        protected async override void OnAppearing()
        {
            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/reservacions/Getreservacion");
            var miArreglo = await client.GetStringAsync(URL);
            var JSON_cliente = JsonConvert.DeserializeObject<List<Model.Modeldb.reservacion>>(miArreglo);
            foreach (var item in JSON_cliente)
            {
                 //&& item.estado == 1
                if (item.idcliente == Constantes.idusuario)
                {
                    Constantes.idreservacion = item.id;
                }
            }
            if (Constantes.idreservacion!=0)
            {
                msje.Text = "Hola!" + Constantes.nombre + " - " +Constantes.idreservacion;
            }
            else
            {
                var nuevareservacion = new Model.Modeldb.reservacion() {
                    idcliente = Constantes.idusuario,
                    //total = 0,
                    //idubicacion = 1,
                    //idproducto = 0,
                    //cantidad = 0,
                    
                };
                
                var json = JsonConvert.SerializeObject(nuevareservacion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client = new HttpClient();
                var result = await client.PostAsync("http://paraisoreal19.somee.com/api/reservacions/Postreservacion", content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await App.Current.MainPage.DisplayAlert("Respuesta", " Inicio de reservacion exitosa", "Ok");
                }
            }
            base.OnAppearing();
            
        }

    }
}