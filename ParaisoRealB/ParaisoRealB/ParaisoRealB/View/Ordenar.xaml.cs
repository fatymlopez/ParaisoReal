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
                precio = Convert.ToDecimal(price.Text),
                cantidad = Convert.ToInt32(cantidad.Text),
                subtotal = Convert.ToDecimal(price.Text) * Convert.ToDecimal(cantidad.Text)
            };

            TotalGlobal.Text = (newreservacion.subtotal).ToString();

            var json = JsonConvert.SerializeObject(newreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(Constantes.Base + "/api/detallereservacions/Postdetallereservacion", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "SubTotal" + newreservacion.subtotal, "Ok");
                cantidad.Text = string.Empty;
                TotalGlobal.Text = string.Empty;
                nomproduct.Text = string.Empty;

              
            }

            HttpClient client2 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/detallereservacions/Getdetallereservacion");
            var miArreglo = await client2.GetStringAsync(URL);
            var JSON_DRESERVACION = JsonConvert.DeserializeObject<List<Model.Modeldb.detallereservacion>>(miArreglo);
            decimal totalglobal = 0;
            await DisplayAlert("mensaje", "total" + totalglobal, "ok");
            foreach (var item in JSON_DRESERVACION)
            {
                if (item.idreservacion == Constantes.idreservacion)
                {
                    
                    totalglobal += Convert.ToDecimal(item.subtotal);

                    await DisplayAlert("mensaje", "total" + totalglobal, "ok");
                }

            }
            //aqui ya no se toca

           await DisplayAlert("mensaje","total fuera de for "+totalglobal,"ok");
            //put

             /*var actualizarreservacion = new Model.Modeldb.reservacion
             {
                 id = Constantes.idreservacion,
                 idcliente = Constantes.idusuario,
                 total = totalglobal,
                 estado = 1
             };
             */
            var actualizar = new reservacionpr
            {
                id=Constantes.idreservacion,
                idcliente=Constantes.idusuario,
                total=totalglobal,
                estado =1,
                idubicacion =1
            };

            await DisplayAlert("mensaje", "sacando el total" + actualizar.total, "ok");
            await DisplayAlert("mensaje", "sacando el id" + actualizar.id, "ok");
            await DisplayAlert("mensaje", "sacando el idcliente" + actualizar.idcliente, "ok");
            await DisplayAlert("mensaje", "sacando el estado" + actualizar.estado, "ok");

            var url = string.Format(Constantes.Base + "/api/reservacions/Putreservacion/" + Constantes.idreservacion);

            await DisplayAlert("mensaje", "url: " + url, "ok");
            var jsona = JsonConvert.SerializeObject(actualizar);
            var contenta = new StringContent(jsona, Encoding.UTF8, "application/json");
            await DisplayAlert("mensaje", "array" +contenta, "ok");
            
            HttpClient client3 = new HttpClient();
            HttpResponseMessage resulta = null;
           resulta = await client3.PutAsync(url, contenta);
           
            if (resulta.IsSuccessStatusCode)
            {
                await DisplayAlert("mensaje", "entra al if"+resulta, "ok");

            }
            else
            {
                await DisplayAlert("Mensaje", "entra al else"+resulta, "ok");
            }

        }

        public async void BtnverOrden_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }
    }


}
