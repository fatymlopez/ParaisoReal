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
            getAntojitos();		
        }

        public object ListDesayuno { get; private set; }

        public async void getAntojitos()
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base +"/api/productoss/Getproductos");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idcategoria == 4 && a.existencia > 0);
            ListAntojitos.ItemsSource = nuevalista;


        }
    }
}
