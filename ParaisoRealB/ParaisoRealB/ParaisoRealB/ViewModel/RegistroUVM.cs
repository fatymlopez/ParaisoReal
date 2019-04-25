using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.View;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.ComponentModel;

namespace ParaisoRealB.ViewModel 
{
   public class RegistroUVM : ViewModelBase, INotifyPropertyChanged
    {
        public RegistroUVM()
        {
            RegistroCommand = new Command(RegistroUsu);
        }

        public  async void RegistroUsu()
        {
            if (this.nombreclcommand== null || this.cellclcommand == null || this.emailclcommand == null || this.passclcommand == null)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Debe ingresar todos los datos", "Ok");
            }
            else
            {
                var newcliente = new cliente()
                {
                    nombrecl = this.nombreclcommand,
                    cellcl = this.cellclcommand,
                    emailcl = this.emailclcommand,
                    passcl = this.passclcommand

                };

                var json = JsonConvert.SerializeObject(newcliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync(Constantes.Base + "/api/clientes/Postcliente", content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync( new Login());

                }

            }
            
                 
        }

        #region propiedades
        private string _nombreclcommand;
        public string nombreclcommand
        {
            get { return _nombreclcommand; }
            set { _nombreclcommand = value; RaisePropertyChanged(); }
        }

        private string _cellclcommand;
        public string cellclcommand
        {
            get { return _cellclcommand; }
            set { _cellclcommand = value;  RaisePropertyChanged(); }
        }

        private string _emailclcommand;
        public string emailclcommand
        {
            get { return _emailclcommand; }
            set { _emailclcommand = value;  RaisePropertyChanged(); }
        }

        private string _passclcommand;
        public string passclcommand
        {
            get { return _passclcommand; }
            set { _passclcommand = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Comandos
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
