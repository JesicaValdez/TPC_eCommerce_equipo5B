using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Evento> ListaEventos { get; set; }
        public ImagenNegocio negocioImagen = new ImagenNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEventosEnCarrusel();
            }
        }

        private void CargarEventosEnCarrusel()
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<Evento> listaEventos = eventoNegocio.listarEventos();

            if (listaEventos.Count > 0)
            {
                for (int i = 0; i < listaEventos.Count; i++)
                {
                    var evento = listaEventos[i];
                    string imagenUrl = (evento.imagenes != null && evento.imagenes.Count > 0) ? evento.imagenes[0].Url : "ruta/imagen_por_defecto.jpg";
                    string nombreEvento = evento.nombre;
                    string fechaEvento = evento.fecha.ToString("dddd, dd 'de' MMMM 'de' yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    // Determina si este es el primer evento para marcarlo como activo
                    string activeClass = (i == 0) ? "active" : "";

                    // Construcción del HTML para cada evento
                    carouselInner.InnerHtml += $@"
                        <div class='carousel-item {activeClass}'>
                            <img src='{imagenUrl}' class='d-block w-100' alt='{nombreEvento}' style='width: 100%; max-height: 400px; object-fit: cover;'>
                            <div class='carousel-caption d-none d-md-block'>
                                <h5>{nombreEvento}</h5>
                                <p>{fechaEvento}</p>
                            </div>
                        </div>";
                }
            }
        }

    }
}
