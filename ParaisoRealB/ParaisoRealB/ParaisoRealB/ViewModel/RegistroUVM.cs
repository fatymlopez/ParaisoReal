using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealB.Model.Modeldb;
using ParaisoRealB.View;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace ParaisoRealB.ViewModel
{
   public class RegistroUVM
    {
        public RegistroUVM()
        {
            RegistroCommand = new Command(RegistroUsu);
        }

        public  async void RegistroUsu()
        {
           
            cliente newcliente = new cliente()
            {
                nombrecl = nombreclcommand,
                cellcl = cellclcommand,
                emailcl = emailclcommand,
                passcl = passclcommand

            };

            var json = JsonConvert.SerializeObject(newcliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/clientes/Postcliente", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");

              
            }

        
        }

        #region propiedades
        public string nombreclcommand { get; set; }
        public string cellclcommand { get; set; }
        public string emailclcommand { get; set; }
        public string passclcommand { get; set; }
        #endregion



        #region Comandos
        public Command RegistroCommand { get; set; }
        #endregion
    }
}
