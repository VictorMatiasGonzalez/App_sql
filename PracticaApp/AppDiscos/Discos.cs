using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiscos
{
    class Discos
    {
        public string  Titulo { get; set; }
        public  DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagenTapa { get; set; }
        public Estilos Genero { get; set; }
        public TiposEdicion Edition { get; set; }



    }
}
