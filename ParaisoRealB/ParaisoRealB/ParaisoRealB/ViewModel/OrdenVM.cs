using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
    public class OrdenVM
    {
        public OrdenVM()
        {
            VerOrdenCommand = new Command(VerOrdenC);
            OrdenarCommand = new Command(VerReservavion);

        }

        public  void VerReservavion()
        {
            App.Current.MainPage.DisplayAlert("Genial!", "Has Realizado con Exito tu Pedido", "Ok");
            App.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }

        public void VerOrdenC()
        {
           //App.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }

        #region comandos
        public Command OrdenarCommand { get; set; }
        public Command VerOrdenCommand { get; set; }
        #endregion
    }


}
