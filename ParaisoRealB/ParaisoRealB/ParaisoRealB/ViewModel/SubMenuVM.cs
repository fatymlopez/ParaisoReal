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
                new SubMenuModel(){Icono = "", Titulo="Iniciar Sesion o Registrate"},
                new SubMenuModel(){Icono="", Titulo="Quienes Somos"},
                new SubMenuModel(){Icono="", Titulo="Nuestros Servicios"},
                new SubMenuModel(){Icono="", Titulo="Contactanos"}

                
            };

        }

        

        #region propiedades
        public ObservableCollection<SubMenuModel> MenuItems { get; set; }
       

        private SubMenuModel _selectedMenuItem;

        public SubMenuModel SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set {

                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                   
                    Seleccion();
           
                 
                      
                }
               
                
            }
        }

  

        public async void Seleccion()
        {
            
                await App.Current.MainPage.Navigation.PushAsync(new Login());
        }
          
        
        #endregion
    }
}

