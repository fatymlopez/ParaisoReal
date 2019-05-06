using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParaisoRealB.ViewModel;
using ParaisoRealB.Model;
using System.Collections.ObjectModel;

namespace ParaisoRealB.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubMenu : ContentPage 
	{
		public SubMenu ()
		{
			InitializeComponent ();
                     
        }
     
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                ViewModel.SubPageVM pageData = args.SelectedItem as ViewModel.SubPageVM;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                //Constantes.idreservacion = 0;
                //Constantes.idusuario = 0;
                //Constantes.estados = 0;
                //Constantes.usuario = "";
                //Constantes.contraseña = "";
                //Constantes.nombre = "";
                await Navigation.PushAsync(page);

             

                
            }
        }

       


        
    }
}