using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNegocio
{
    public class Llamada
    {
        public DateTime Fecha { get; set; }
        public string numeroDestino { get; set; }
        public int Duracion  { get; set; }

        public Llamada( DateTime fecha, string numeroDestino, int duracion)
        {
            this.Fecha = fecha;
            this.numeroDestino = numeroDestino;
            this.Duracion = duracion;
            
        }
    }
}
