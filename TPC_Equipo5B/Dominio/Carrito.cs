using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Carrito : Entrada
    {
        List<Entrada> listaEntradas;

        public void sumarEntradasAlCarrito(Entrada entrada)
        {
            listaEntradas.Add(entrada);
        }

        public int cantidadentradas()
        {
            return listaEntradas.Count();
        }
    }
}
