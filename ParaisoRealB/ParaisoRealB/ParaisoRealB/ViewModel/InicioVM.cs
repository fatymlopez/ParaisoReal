using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
    public class InicioVM
    {
        public InicioVM()
        {
            InicioCommand = new Command(MenuP);

        }

       public async void MenuP()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MenuPpal());
        }

        #region Comandos
        public Command InicioCommand { get; set; }
        #endregion

    }
}
