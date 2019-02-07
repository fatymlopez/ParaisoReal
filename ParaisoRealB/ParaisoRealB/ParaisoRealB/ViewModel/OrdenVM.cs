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

        }

        public void VerOrdenC()
        {
            App.Current.MainPage.Navigation.PushAsync(new VerOrden());
        }

        #region comandos
        public Command OrdenarCommand { get; set; }
        public Command VerOrdenCommand { get; set; }
        #endregion
    }


}
