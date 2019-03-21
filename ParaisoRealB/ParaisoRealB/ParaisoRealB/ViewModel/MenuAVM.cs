using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.View;
using Xamarin.Forms;

namespace ParaisoRealB.ViewModel
{
   public class MenuAVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private List<categorias> listCategoria;

        public List<categorias> ListCategoria
        {
            get { return listCategoria; }
            set { listCategoria = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<productos> listMenu;

        public ObservableCollection<productos> ListMenu
        {
            get { return listMenu; }
            set { listMenu = value; RaisePropertyChanged(); }
        }

        private categorias selectedCategory;

        public categorias SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                var name = selectedCategory.nomcategoria;
                var id = selectedCategory.id;
                App.Current.MainPage.DisplayAlert("Nombre de la categoria", name + " el id es: " + id, "oki");
            }
        }


        public MenuAVM()
        {
            ordenaraqui = new Command(pasarpage);
            ListMenu = new ObservableCollection<productos>();
            ListMenu.Add(new productos
            {
                id = 1,
                nomproducto = "Combo 1",
               // precio = "",
                descripcion = "Frijoles, Platano, Café, Pan frances"
            });
            ListMenu.Add(new productos
            {
                id = 2,
                nomproducto = "Combo 2",
                //precio = "2.50",
                descripcion = "Frijoles, Platano, Café, Pan frances, pan dulce"
            });
            getCategoria();

        }

        public async void pasarpage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }


        #region comandos
        public Command ordenaraqui { get; set; }
        #endregion

        public async void getCategoria()
        {
            var cliente = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/categoriass/Getcategorias");
            // var resp = await cliente.GetAsync(URL);
            var miArreglo = await cliente.GetStringAsync(URL);
            //var result = resp.Content.ReadAsStringAsync().Result;
            //JObject values = JObject.Parse(result);
            ListCategoria = JsonConvert.DeserializeObject<List<categorias>>(miArreglo);
            //int lon = values.Count;
            //Debug.WriteLine(lon);
            Debug.WriteLine(ListCategoria);

        }
        private void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                if (!string.IsNullOrEmpty(propertyname))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }



    }
}
