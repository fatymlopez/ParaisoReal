using Newtonsoft.Json;
using ParaisoRealB.Model;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerOrden : ContentPage
    {
        public VerOrden()
        {
            InitializeComponent();

            BindingContext = this;
            getpicker();
            getorder();
            gettotal();
          
        }

        public async void gettotal()
        {
            HttpClient clientotal = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/detallereservacions/Getdetallereservacion");
            var miArreglo = await clientotal.GetStringAsync(URL);
            var JSON_DRESERVACION = JsonConvert.DeserializeObject<List<Model.Modeldb.detallereservacion>>(miArreglo);
            totalfinal = 0;
           
            foreach (var item in JSON_DRESERVACION)
            {
                if (item.idreservacion == Constantes.idreservacion)
                {

                    totalfinal += Convert.ToDecimal(item.subtotal);

                    tttal.Text = "Total a Pagar"+" "+"$"+totalfinal;
                }

            }
        }

        public async void getorder()
        {
            var client1 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/detallereservacions/Getdetallereservacion");
            var miArreglo1 = await client1.GetStringAsync(URL);
            var JSON_ORDER = JsonConvert.DeserializeObject<List<Model.Modeldb.detallereservacion>>(miArreglo1);
            var NewOrderList = JSON_ORDER.Where(i => i.idreservacion == Constantes.idreservacion && i.reservacion.estado == 1);
            ListDetalle.ItemsSource = NewOrderList;

        }

        public async void getpicker()
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/ubicacions/Getubicacion");
            var miArreglo = await client.GetStringAsync(URL);
            Itemcategory = JsonConvert.DeserializeObject<List<ubicacion>>(miArreglo);
            Debug.WriteLine(Itemcategory);
        }


        public void Cancelar_Clicked(object sender, EventArgs e)
        {


        }

        public async void Ordenar_Clicked(object sender, EventArgs e)
        {

            var guardarreserva = new reservacionpr
            {
                id = Constantes.idreservacion,
                idcliente = Constantes.idusuario,
                total = totalfinal,
                estado = 0,
                idubicacion = this.idss
            };

            await DisplayAlert("mensaje", "sacando el total" + guardarreserva.total, "ok");
            await DisplayAlert("mensaje", "sacando el id" + guardarreserva.id, "ok");
            await DisplayAlert("mensaje", "sacando el idcliente" + guardarreserva.idcliente, "ok");
            await DisplayAlert("mensaje", "sacando el estado" + guardarreserva.estado, "ok");

            var url = string.Format(Constantes.Base + "/api/reservacions/Putreservacion/" + Constantes.idreservacion);

            await DisplayAlert("mensaje", "url: " + url, "ok");
            var jsona = JsonConvert.SerializeObject(guardarreserva);
            var contenta = new StringContent(jsona, Encoding.UTF8, "application/json");
            await DisplayAlert("mensaje", "array" + contenta, "ok");

            HttpClient client3 = new HttpClient();
            HttpResponseMessage resulta = null;
            resulta = await client3.PutAsync(url, contenta);

            if (resulta.IsSuccessStatusCode)
            {
                await DisplayAlert("mensaje", "entra al if" + resulta, "ok");

            }
            else
            {
                await DisplayAlert("Mensaje", "entra al else" + resulta, "ok");
            }


        }

        #region propiedades
        private List<ubicacion> _itemcategory;

        public List<ubicacion> Itemcategory
        {
            get { return _itemcategory; }
            set { _itemcategory = value; OnPropertyChanged(); }
        }

        private int _idss;
        public int idss
        {
            get { return _idss; }
            set { _idss = value; OnPropertyChanged(); }
        }

        private decimal _totalfinal;
        public decimal totalfinal
        {
            get { return _totalfinal; }
            set { _totalfinal = value;
                OnPropertyChanged(); }
        }

        private ubicacion _selectcategory;
      

        public ubicacion selectcategory
        {
            get { return _selectcategory; }
            set
            {
                _selectcategory = value;
                var name = _selectcategory.nomubicacion;
                idss = _selectcategory.id;
                App.Current.MainPage.DisplayAlert("Ubicacion Seleccionada", name, "Ok");
            }
        }

        #endregion

        public void ListDetalle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            (sender as ListView).SelectedItem = null;


        }
    }
}