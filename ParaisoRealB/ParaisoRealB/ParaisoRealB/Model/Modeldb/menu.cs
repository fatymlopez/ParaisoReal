using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealB.Model.Modeldb
{
    public class menu
    {
        public int id { get; set; }
        public int idcategoria { get; set; }
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }

    }
}
