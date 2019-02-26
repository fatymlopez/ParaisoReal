using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ParaisoRealB.Model;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
    public class UbicacionVM
    {
        public UbicacionVM()
        {
            ItemsUbicacion = new ObservableCollection<ubicacion>
            {
                new ubicacion(){nomubicacion = "Ciudad Universitaria UNIVO"},
                new ubicacion(){nomubicacion ="Sede Central UNIVO"},
                new ubicacion(){nomubicacion ="Universidad Modular Abierta UMA"}

            };

        }

        #region propiedades
        public ObservableCollection<ubicacion> ItemsUbicacion { get; set; }
        
        private ubicacion _ubicacionSelect;

        public ubicacion UbicacionSelect
        {
            get { return _ubicacionSelect; }
            set {

                if (_ubicacionSelect != value)
                {
                    _ubicacionSelect = value;
                    HandleSelectedItem();
                }
              
            }
        }

        async void HandleSelectedItem()
        {
            //validar ojo!
            await App.Current.MainPage.Navigation.PushAsync(new MasterMenu());
        }

        #endregion
    }

}
