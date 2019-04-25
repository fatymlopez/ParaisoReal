using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ParaisoRealB.Model.Modeldb
{
    public class reservacion
    {
      
        public int id { get; set; }
        public int? idcliente { get; set; }
        public decimal? total { get; set; }
        public int? estado { get; set; }
        public int? idubicacion { get; set; }
        
        public ICollection<detallereservacion> detallereservacion { get; set; }
       
    }
}
