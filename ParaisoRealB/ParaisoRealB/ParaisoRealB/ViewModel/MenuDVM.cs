﻿using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.ViewModel
{
   public class MenuDVM : INotifyPropertyChanged
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


        public MenuDVM()
        {
            /*ListMenu = new ObservableCollection<productos>();
            ListMenu.Add(new productos
            {
                id = 1,
                nomproducto = "Combo 1",
                //precio = 2.5,
                descripcion = "Frijoles, Platano, Café, Pan frances"
                

            });
            ListMenu.Add(new productos
            {
                id = 2,
                nomproducto = "Combo 2",
               // precio = 2.5,
                descripcion = "Frijoles, Platano, Café, Pan frances, pan dulce"
                
            });
            getCategoria();

            Ordenarhoy = new Command(PantallaOrder);*/

        }

      
        public async void PantallaOrder()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }

        public async void getCategoria()
        {
            var cliente = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/categoriass/Getcategorias");
            var miArreglo = await cliente.GetStringAsync(URL);
            ListCategoria = JsonConvert.DeserializeObject<List<categorias>>(miArreglo);
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
