using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealB.Model;

namespace ParaisoRealB.ViewModel
{
   public class MenuAnVM : MenuAModel
    {
        public MenuAnVM(Type typea, string titulo, double precio)
        {
            TypeA = typea;
            Titulo = titulo;
        
            //Precio = precio;
        }

        static MenuAnVM()
        {
            All = new List<MenuAnVM>
            {

                new MenuAnVM(typeof(View.Ordenar), "Pupusas", 0.50),
                new MenuAnVM(typeof(View.Ordenar), "HotDog", 0.50)
                



            };
        }

        #region propiedades
        public static IList<MenuAnVM> All { private set; get; }
        #endregion
    }
}
