using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
    public class VerOrdenVM
    {
        public VerOrdenVM()
        {
            DecisionCommand = new Command(Redireccion);
            AgregarCommand = new Command(AgregarOtraOrden);
        }

        public void AgregarOtraOrden()
        {
         
            
                App.Current.MainPage.Navigation.PushAsync(new MenuAlmuerzos());
            

           
        }

        public void Redireccion()
        {
           
            //ojo hacer una validacion


            App.Current.MainPage.Navigation.PushAsync(new Login());
        }

     

        #region Comandos
        public Command DecisionCommand { get; set; }
        public Command AgregarCommand { get; set; }
        #endregion
    }
}
