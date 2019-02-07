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
    public partial class MenuAlmuerzos : ContentPage
    {
       

        public MenuAlmuerzos()
        {
            InitializeComponent();

        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                ViewModel.MenuAVM pageData = args.SelectedItem as ViewModel.MenuAVM;
                Page page = (Page)Activator.CreateInstance(pageData.TypeA);
                await Navigation.PushAsync(page);


            }
        }

    }
}
