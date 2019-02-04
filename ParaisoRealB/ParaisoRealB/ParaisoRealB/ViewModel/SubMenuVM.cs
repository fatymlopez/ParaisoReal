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


          /* MenuItems = new ObservableCollection<SubMenuModel>();
            {
                var page1 = new SubMenuModel() { Icono = "user", Titulo = "Iniciar Sesion o Registrate", TargetType = typeof(Login) };
                var page2 = new SubMenuModel() { Icono = "", Titulo = "Quienes Somos", TargetType = typeof(InfEmpresa) };
                var page3 = new SubMenuModel() { Icono = "", Titulo = "Nuestros Servicios", TargetType = typeof(InfServicios) };
                var page4 = new SubMenuModel() { Icono = "", Titulo = "Contactanos", TargetType = typeof(InfContactos) };
                var page5 = new SubMenuModel() { Icono = "", Titulo = "Salir",  TargetType = typeof(Inicio) };

                MenuItems.Add(page1);
                MenuItems.Add(page2);
                MenuItems.Add(page3);
                MenuItems.Add(page4);
                MenuItems.Add(page5);

               
                
            };*/

        }       

     /* #region propiedades
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
                        _selectedMenuItem = null;

                        App.Current.MainPage.Navigation.PushAsync(new Login());                       
                                              
                    }
                    else if (i == 2)

                    {
                        App.Current.MainPage.Navigation.PushAsync(new InfEmpresa());
                    }
                    else if (i == 3)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new InfServicios());

                    }
                    else if (i == 4)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new InfContactos());
                    }
                    else if (i == 5)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new Inicio());

                    }
                    

                  
                }
               
                
            }
        }
        
        #endregion*/
    }
}

