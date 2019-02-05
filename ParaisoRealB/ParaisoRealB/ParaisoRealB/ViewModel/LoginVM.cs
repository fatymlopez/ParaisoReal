using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
   public  class LoginVM
   {
        public LoginVM()
        {
            RegistroCommand = new Command(FormularioR);

        }

       public async void FormularioR()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegitroUsuario());
        }
        #region Comandos
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
