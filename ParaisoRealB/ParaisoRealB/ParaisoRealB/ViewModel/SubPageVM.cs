﻿using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealB.Model;


namespace ParaisoRealB.ViewModel
{
    public class SubPageVM  : SubMenuModel
    {
        public SubPageVM(Type type, string titulo, string icono)
        {
            Type = type;
            Titulo = titulo;
            Icono = icono;
            
        }
      
        static SubPageVM()
        {
            All = new List<SubPageVM>
            {
           
                new SubPageVM(typeof(View.Login), "Iniciar Sesion", "users"),
                new SubPageVM(typeof(View.InfEmpresa), "Quienes Somos", "quien"),
                new SubPageVM(typeof(View.InfEmpresa), "Nuestros Servicios", "ser"),
                new SubPageVM(typeof(View.InfEmpresa), "Contactanos", "cell")



            };
        }

        #region propiedades
        public static IList<SubPageVM> All { private set; get; }
        #endregion
    }

}
