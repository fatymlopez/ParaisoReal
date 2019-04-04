using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ordenar : ContentPage
    {
        public Ordenar()
        {
            InitializeComponent();

        }

        public async void BtnOrdenar_Clicked(object sender, EventArgs e)
        {

            var newreservacion = new detallereservacion
            {
                idreservacion = Constantes.idreservacion,
                idproducto = Convert.ToInt32(idd.Text),
                cantidad = Convert.ToInt32(cantidad.Text),
                subtotal = Convert.ToDecimal(price.Text) * Convert.ToDecimal(cantidad.Text)
            };

            Total.Text = (newreservacion.subtotal).ToString();
            
            var json = JsonConvert.SerializeObject(newreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/detallereservacions/Postdetallereservacion", content);

            procesos.operaciones instanceprocesos = new procesos.operaciones(Constantes.idusuario, Constantes.idreservacion);
             
            if (result.StatusCode == HttpStatusCode.Created)
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", $"Realizado, total actual: {instanceprocesos.totalglobal}", "Ok");
                await Application.Current.MainPage.Navigation.PopAsync();

            }

        }

        public async void BtnverOrden_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new VerOrden());

        }
    }

     
    }
