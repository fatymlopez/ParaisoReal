using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealB.View;

namespace ParaisoRealB.ViewModel
{
    public class SubPageVM 
    {
        public SubPageVM(Type type, string titulo, string icono)
        {
            Type = type;
            Titulo = titulo;
            Icono = icono;
        }

        public Type Type { private set; get; }

        public string Titulo { private set; get; }

        public string Icono { private set; get; }

        static SubPageVM()
        {
            All = new List<SubPageVM>
            {
                // Part 1. Getting Started with XAML
                new SubPageVM(typeof(View.Login), "Iniciar Sesion", "user"),
                new SubPageVM(typeof(View.InfEmpresa), "Iniciar Sesion", "user")


               /* new PageDataViewModel(typeof(XamlPlusCodePage), "XAML + Code",
                                      "Interact with a Slider and Button"),

                // Part 2. Essential XAML Syntax
                new PageDataViewModel(typeof(GridDemoPage), "Grid Demo",
                                      "Explore XAML syntax with the Grid"),

                new PageDataViewModel(typeof(AbsoluteDemoPage), "Absolute Demo",
                                      "Explore XAML syntax with AbsoluteLayout"),

                // Part 3. XAML Markup Extensions
                new PageDataViewModel(typeof(SharedResourcesPage), "Shared Resources",
                                      "Using resource dictionaries to share resources"),

                new PageDataViewModel(typeof(StaticConstantsPage), "Static Constants",
                                      "Using the x:Static markup extensions"),

                new PageDataViewModel(typeof(RelativeLayoutPage), "Relative Layout",
                                      "Explore XAML markup extensions"),

                // Part 4. Data Binding Basics
                new PageDataViewModel(typeof(SliderBindingsPage), "Slider Bindings",
                                      "Bind properties of two views on the page"),

                new PageDataViewModel(typeof(SliderTransformsPage), "Slider Transforms",
                                      "Use Sliders with reverse bindings"),

                new PageDataViewModel(typeof(ListViewDemoPage), "ListView Demo",
                                      "Use a ListView with data bindings"),

                // Part 5. From Data Bindings to MVVM
                new PageDataViewModel(typeof(OneShotDateTimePage), "One-Shot DateTime",
                                      "Obtain the current DateTime and display it"),

                new PageDataViewModel(typeof(ClockPage), "Clock",
                                      "Dynamically display the current time"),

                new PageDataViewModel(typeof(HslColorScrollPage), "HSL Color Scroll",
                                      "Use a view model to select HSL colors"),

                new PageDataViewModel(typeof(KeypadPage), "Keypad",
                                      "Use a view model for numeric keypad logic")*/
            };
        }

        #region propiedades
        public static IList<SubPageVM> All { private set; get; }
        #endregion
    }

}
