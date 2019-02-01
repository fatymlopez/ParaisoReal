using ParaisoRealB.Model;
using ParaisoRealB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;


namespace ParaisoRealB.ViewModel
{
    public class SubMenuVM
    {
        public SubMenuVM()
        {
           

            MenuItems = new ObservableCollection<SubMenuModel>
            {
                new SubMenuModel(){Icono = "user", Titulo="Iniciar Sesion o Registrate",identificador=1},
                new SubMenuModel(){Icono="", Titulo="Quienes Somos",identificador=2},
                new SubMenuModel(){Icono="", Titulo="Nuestros Servicios",identificador=3},
                new SubMenuModel(){Icono="", Titulo="Contactanos",identificador=4}

                
            };

        }       

       #region propiedades
        public ObservableCollection<SubMenuModel> MenuItems { get; set; }
       

        private SubMenuModel _selectedMenuItem;

        public SubMenuModel SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set {
                 _selectedMenuItem = value;

                if (_selectedMenuItem != null)
                {
                    int i = _selectedMenuItem.identificador;
                    if (i == 1)
                    {
                       
                        App.Current.MainPage.Navigation.PushAsync(new Login()) ;
                    } else if (i ==  2)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new MenuPpal());
                    }
                  
                }
               
                
            }
        }
        
        #endregion
    }
}

