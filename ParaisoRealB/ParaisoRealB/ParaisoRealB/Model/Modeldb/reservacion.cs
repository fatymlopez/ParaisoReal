using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealB.Model.Modeldb
{
    public class reservacion
    {
        public int id { get; set; }
        public int? idcliente { get; set; }
        public decimal? total { get; set; }
        public int? estado { get; set; }

        public List<detallereservacion> detallereservacions { get; set; }
    }
}
