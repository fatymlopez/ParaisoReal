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
            ItemsUbicacion = new ObservableCollection<UbicacionModel>
            {
                new UbicacionModel(){Nombre = "Ciudad Universitaria UNIVO"},
                new UbicacionModel(){Nombre="Sede Central UNIVO"},
                new UbicacionModel(){Nombre="Universidad Modular Abierta UMA"}

            };

        }

        #region propiedades
        public ObservableCollection<UbicacionModel> ItemsUbicacion { get; set; }
        
        private UbicacionModel _ubicacionSelect;

        public UbicacionModel UbicacionSelect
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
            await App.Current.MainPage.Navigation.PushAsync(new MenuPpal());
        }

        #endregion
    }

}
