using ParaisoRealB.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.ViewModel
{
    public class MenuPpalVM
    {
        public MenuPpalVM()
        {
            Tapcommand = new Command(Mdesayuno);
            Tapcommand2 = new Command(Malmuerzos);
            Tapcommand3 = new Command(Mantojitos);
        }

        public async void Mantojitos(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MenuAntojitos());
        }

        public async void Malmuerzos(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MenuAlmuerzos());
        }

        public async void Mdesayuno(object obj)
        {
           await App.Current.MainPage.Navigation.PushAsync(new MenuDesayuno());

        }

        #region comandos
        public Command Tapcommand { get; set; }
        public Command Tapcommand2 { get; set; }
        public Command Tapcommand3 { get; set; }
        #endregion
    }
}
