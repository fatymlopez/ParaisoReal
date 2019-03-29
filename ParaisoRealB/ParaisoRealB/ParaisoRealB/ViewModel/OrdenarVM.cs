using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealB.ViewModel
{
    public class OrdenarVM
    {
        public OrdenarVM()
        {
            btnOrdenar = new Command(ordenarreserva);

        }

        public void ordenarreserva()
        {
            
        }

        #region comandos
        public Command btnOrdenar { get; set; }
        #endregion
    }
}
