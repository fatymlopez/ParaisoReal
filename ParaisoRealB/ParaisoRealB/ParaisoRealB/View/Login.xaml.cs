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

            indicator.IsRunning = true;
            IniciarS.IsEnabled = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://paraisoreal19.somee.com");
            string url = string.Format("http://paraisoreal19.somee.com/api/clientes/Getcliente/{0}/{1}", correousu.Text, Password.Text);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStreamAsync().Result;
            indicator.IsRunning = false;
            IniciarS.IsEnabled = true;
          
            if (string.IsNullOrEmpty (result.ToString()) || result.ToString() == "null")
            {
                await App.Current.MainPage.DisplayAlert("Error", "", "Ok");
                Password.Text = string.Empty;
                Password.Focus(); 
                return;
            }

            await App.Current.MainPage.Navigation.PushAsync(new MenuPpal());
         


        }
    }
}