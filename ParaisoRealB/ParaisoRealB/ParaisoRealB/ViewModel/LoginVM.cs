using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.View;
using ParaisoRealB.Model.Modeldb;

namespace ParaisoRealB.ViewModel
{
   public  class LoginVM 
   {
        public LoginVM()
        {
            RegistroCommand = new Command(FormularioR);
           // MenusCommand = new Command(VerMenus);
        }
        /*public async void VerMenus()
        {
            if (string.IsNullOrEmpty(contracommand)) 
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar un usuario", "Ok");
                contracommand.Focus();
                return;
            }
            await App.Current.MainPage.Navigation.PushAsync(new MasterMenu());
        }*/

        public async void FormularioR()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegitroUsuario());
        }

        #region propiedades   
        //public string correocommand { get; set; }
        //public string contracommand { get; set; }
        #endregion

        #region Comandos
        //public Command MenusCommand { get; set; }
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
