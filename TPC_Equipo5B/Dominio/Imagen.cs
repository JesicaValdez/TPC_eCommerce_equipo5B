﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public string CodigoEvento { get; set; }
        public string Url { get; set; }
        
        public Imagen()
        {
            CodigoEvento = "";
            Url = "";
        }
    }
}
