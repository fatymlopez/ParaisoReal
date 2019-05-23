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
using ParaisoRealB.Model.Modeldb;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPpal : ContentPage
    {       
        public MenuPpal()
        {
            InitializeComponent();
            
        }

        //nuevo prueba
        protected  override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => 
            {
                var result = await DisplayAlert("Mensaje", "Desea salir de la Aplicacion", "SI", "NO");
                
                if (true)
                {
                    Constantes.idreservacion = 0;
                    Constantes.idusuario = 0;
                    Constantes.estados = 0;
                    Constantes.usuario = "";
                    Constantes.contraseña = "";
                    Constantes.nombre = "";
                    await Navigation.PopAsync();
                   
                }
                
            });
            return base.OnBackButtonPressed();
            //return true;
        }

        //nuevo prueba final

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base +"/api/reservacions/Getreservacion");
            var miArreglo = await client.GetStringAsync(URL);
            var JSON_cliente = JsonConvert.DeserializeObject<List<Model.Modeldb.reservacion>>(miArreglo);
            foreach (var item in JSON_cliente)
            {
                if (item.idcliente == Constantes.idusuario && item.estado==1)
                {
                   
                        Constantes.idreservacion = item.id;
                        Constantes.estados = Convert.ToInt32(item.estado);
                        //break;
                    
                }
               
            }
            if (Constantes.idreservacion != 0 && Constantes.estados == 1)
            {
                // msje.Text = "Hola " + Constantes.nombre + " - " + Constantes.idreservacion;
                msje.Text = "Hola " + Constantes.nombre;
                //que se mantenga el id
            }

            //sino  que pase esto
            else
            {
               
                var nuevareservacion = new Model.Modeldb.reservacion()
                {
                    id = 0,
                    idcliente = Constantes.idusuario,
                    total = 0,
                    estado = 1,
                    //idubicacion = 1

                };

                var json = JsonConvert.SerializeObject(nuevareservacion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client = new HttpClient();
                var result = await client.PostAsync(Constantes.Base + "/api/reservacions/Postreservacion", content);
                if (result.StatusCode == HttpStatusCode.Created)
                {
                     await Application.Current.MainPage.DisplayAlert("Mensaje", " Inicio de reservacion exitosa", "Ok");
                    //msje.Text = "Hola " + Constantes.nombre + " - " + Constantes.idreservacion;
                     //msje.Text = "Hola " + Constantes.nombre;
                }
            }
            
        }


       
    }
}