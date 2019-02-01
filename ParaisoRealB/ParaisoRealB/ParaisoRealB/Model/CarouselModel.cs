
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.Model
{
    public class CarouselModel 
    {
        public int ids { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public Command TapCommand { get; set; }

        public EventHandler TapClickEventHandler;


        public CarouselModel()
        {
            TapCommand = new Command(() => OnImageClicked());
        }

        private void OnImageClicked()
        {
            TapClickEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
