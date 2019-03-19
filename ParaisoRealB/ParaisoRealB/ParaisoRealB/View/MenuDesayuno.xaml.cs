using ParaisoRealB.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDesayuno : ContentPage
    {
     

        public MenuDesayuno()
        {
            InitializeComponent();
           // BindingContext = new MenuDVM();

        }

        public async void Btndesayuno_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Ordenar()); 
        }
    }
}
