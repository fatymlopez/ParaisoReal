using Newtonsoft.Json;
using ParaisoRealB.Model;
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
		public VerOrden ()
		{
			InitializeComponent ();

            BindingContext = this;

            getpicker();
		}

        public async void getpicker()
        {
            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/ubicacions/Getubicacion");
            var miArreglo = await client.GetStringAsync(URL);
            Itemcategory = JsonConvert.DeserializeObject<List<ubicacion>>(miArreglo);
            Debug.WriteLine(Itemcategory);
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {

        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void Ordenar_Clicked(object sender, EventArgs e)
        {

        }

        #region propiedades
        private List<ubicacion> _itemcategory;

        public List<ubicacion> Itemcategory
        { get { return _itemcategory; }
            set { _itemcategory = value; OnPropertyChanged(); }
        }

        private int _idss;

        public int idss
        {
            get { return _idss; }
            set { _idss = value; OnPropertyChanged(); }
        }

       

        private ubicacion _selectcategory;

        public ubicacion selectcategory
        {
            get { return _selectcategory; }
            set { _selectcategory = value;
                var name = _selectcategory.nomubicacion;
                idss = _selectcategory.id;
                App.Current.MainPage.DisplayAlert("Ubicacion Seleccionada", name, "Ok");
            }
        }

        #endregion
    }
}