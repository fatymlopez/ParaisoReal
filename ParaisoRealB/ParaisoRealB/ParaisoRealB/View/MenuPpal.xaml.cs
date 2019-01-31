using ParaisoRealB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParaisoRealB.ViewModel;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPpal : ContentPage
    {
        public List<CarouselModel> MyDataSource { get; set; }
        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public string Imagen { get; set; }

        public MenuPpal()
        {
            InitializeComponent();

            MyDataSource = new List<CarouselModel>() { new CarouselModel() { Imagen = "Desayuno", Titulo="Desayunos"},
                                                       new CarouselModel() { Imagen = "antojitos", Titulo="Almuerzos"},
                                                       new CarouselModel() { Imagen = "antojitos", Titulo="Antojitos"}};

            BindingContext = this;

        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
         {
             if (Imagen == "Desayuno")
             {
                 await App.Current.MainPage.Navigation.PushAsync(new MenuDesayuno());

             }
             else if (Imagen == "antojitos")
             {
                 await App.Current.MainPage.Navigation.PushAsync(new MenuAlmuerzo());
             }
             else
             {
                 await App.Current.MainPage.Navigation.PushAsync(new MenuAntojitos());
             }

         }
    }
}