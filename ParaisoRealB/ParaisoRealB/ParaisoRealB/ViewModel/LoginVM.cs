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
            MenusCommand = new Command(VerMenus);

        }

        public async void VerMenus()
        {
        
            await App.Current.MainPage.Navigation.PushAsync(new UbicacionView());
        }

        public async void FormularioR()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegitroUsuario());
        }
        #region Comandos
        public Command MenusCommand { get; set; }
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
