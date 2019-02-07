using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealB.Model;

namespace ParaisoRealB.ViewModel
{
   public class MenuAVM : MenuAModel
    {
        public MenuAVM(Type typea, string titulo, string descripcion, double precio)
        {
            TypeA = typea;
            Titulo = titulo;
            Descripcion = descripcion;
            Precio = precio;
        }

        static MenuAVM()
        {
            All = new List<MenuAVM>
            {

                new MenuAVM(typeof(View.Ordenar), "Combo 1", "Carne Azada, Arroz 2 tortillas", 3.00)
             


            };
        }

        #region propiedades
        public static IList<MenuAVM> All { private set; get; }
        #endregion

    }
}
