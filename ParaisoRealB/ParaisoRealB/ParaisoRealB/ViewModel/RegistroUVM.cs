using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.Model;
using ParaisoRealB.View;

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
           {
               

                App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");

            }

        
        }

        #region propiedades
        public string nombreclcommand { get; set; }
        public string emailclcommand { get; set; }
        public string passclcommand { get; set; }
        #endregion



        #region Comandos
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
