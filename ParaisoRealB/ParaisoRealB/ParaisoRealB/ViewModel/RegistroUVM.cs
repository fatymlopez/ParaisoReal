using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.ViewModel
{
   public class RegistroUVM
    {
        public RegistroUVM()
        {
            RegistroCommand = new Command(RegistroUsu);
        }

        public  void RegistroUsu()
        {
            App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
        }

        #region Comandos
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
