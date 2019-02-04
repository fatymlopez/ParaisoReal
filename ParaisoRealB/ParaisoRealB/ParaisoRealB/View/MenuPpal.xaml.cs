using ParaisoRealB.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using ParaisoRealB.ViewModel;

namespace ParaisoRealB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPpal : ContentPage
    {
        public ObservableCollection<CarouselModel> MyDataSource { get; set; }
        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }
        
       

        public MenuPpal()
        {
            InitializeComponent();

           MyDataSource = new ObservableCollection<CarouselModel>()
            {
                new CarouselModel() { Imagen = "Desayuno", Titulo="Desayunos", TapClickEventHandler = OnTapped},
                new CarouselModel() { Imagen = "antojitos", Titulo="Almuerzos", TapClickEventHandler = OnTapped2},
                new CarouselModel() { Imagen = "antojitos", Titulo="Antojitos", TapClickEventHandler = OnTapped3}};
            
            BindingContext = this ;

            

        }
      

        void OnTapped(object sender, EventArgs e)
        {
            var img = (CarouselModel)sender;

            App.Current.MainPage.Navigation.PushAsync(new MenuDesayuno());


        }

        private void OnTapped2(object sender, EventArgs e)
        {
            var img = (CarouselModel)sender;

            App.Current.MainPage.Navigation.PushAsync(new MenuAlmuerzos());


        }

        private void OnTapped3(object sender, EventArgs e)
        {
            var img = (CarouselModel)sender;

            App.Current.MainPage.Navigation.PushAsync(new MenuAntojitos());




        }



    }
}