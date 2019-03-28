using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {       
            Password.IsPassword = Password.IsPassword ? false : true;
        }

        //validacion campos

        public async void IniciarS_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(correousu.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar un usuario", "Ok");
 
                correousu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Password.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar una contraseña", "Ok");
                Password.Focus();
                return;
            }

            //obtener campos...

            indicator.IsRunning = true;
            IniciarS.IsEnabled = false;
            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/clientes/Getcliente");
            var miArreglo = await client.GetStringAsync(URL);
   
            var vercliente = JsonConvert.DeserializeObject<List<cliente>>(miArreglo);
            foreach (var item in vercliente)
            {
                if (item.emailcl == correousu.Text && item.passcl==Password.Text)
                {
                    Constantes.usuario = item.emailcl;
                    Constantes.contraseña = item.passcl;
                    Constantes.nombre = item.nombrecl;
                    Constantes.idusuario = item.id;
                    break;
                }
            }

            indicator.IsRunning = false;
            IniciarS.IsEnabled = true;
            
            if (Constantes.idusuario==0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Datos no validos", "Ok");
                Password.Text = string.Empty;
                Password.Focus(); 
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Bienvenido" + Constantes.nombre, "ok");
                await Application.Current.MainPage.Navigation.PushAsync(new MenuPpal());
                
            }

        }
    }
}