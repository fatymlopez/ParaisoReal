using ParaisoRealB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealB.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPpal : ContentPage
	{
        public List<CarouselModel> MyDataSource { get; set; }
        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public MenuPpal ()
		{
        InitializeComponent ();

            MyDataSource = new List<CarouselModel>() { new CarouselModel() { Image = "Desayuno", Titulo="Desayunos" },
                                                       new CarouselModel() { Image = "antojitos", Titulo="Almuerzos" },
                                                       new CarouselModel() { Image = "antojitos", Titulo="Antojitos" }};

            BindingContext = this;

        }
        

    }
}