﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealB.Model
{
    public class orden
    {
        public int id { get; set; }
        public int idubicacion { get; set; }
        public int idcliente { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        public TimeSpan hora { get; set; }
    }
}
