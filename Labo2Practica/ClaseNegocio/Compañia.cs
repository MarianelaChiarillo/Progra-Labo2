using ClasesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNegocio
{
    public class Compañia
    {
        private string razonSocial;
        private DateTime fechaApertura;
        private Stack<Celular> pilaDeCelus;

        public Compañia(string razonSocial)
        {
            this.razonSocial = razonSocial;
            this.fechaApertura = DateTime.Now;
            this.pilaDeCelus = new Stack <Celular> ();
        }

        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public DateTime FechaApertura { get => fechaApertura; }
        public Stack<Celular> PilaDeCelus { get => pilaDeCelus;}

        public void agregarCelu(Celular celular)
        {
            pilaDeCelus.Push (celular);
        }
        public string MostrarCompañia()
        {
            StringBuilder sb = new StringBuilder ();
            sb.AppendLine($"Razon Social: {razonSocial}");
            sb.AppendLine($"Fecha de apertura: {fechaApertura}");
            sb.AppendLine("-----------------------------------------------------------------------");
            sb.AppendLine($"Celulares de la pila:");

            foreach (var celular in pilaDeCelus)
            {
                sb.AppendLine($"Modelo: {celular.Modelo}, Marca: {celular.Marca}, RAM: {celular.Ram}, Almacenamiento: {celular.Almacenamiento}");

                sb.AppendLine("Contactos:");
                foreach (var contacto in celular.Agenda1)
                {
                    sb.AppendLine($"- Nombre: {contacto.Key.nombre}, Numero: {contacto.Key.numero},  Agendado el: {contacto.Value}");
                }

                sb.AppendLine("Aplicaciones instaladas:");
                foreach (var app in celular.Apps1)
                {
                    sb.AppendLine($"- Nombre: {app.Nombre}, Tamaño: {app.Size}");
                }

                sb.AppendLine("Llamadas realizadas:");
                foreach (var llamada in celular.LlamadasRealizadas)
                {
                    sb.AppendLine($"- Fecha: {llamada.Fecha}, Numero Destino: {llamada.numeroDestino}, Duracion: {llamada.Duracion}");
                }

                sb.AppendLine("-----------------------------------------------------------------------");
                sb.AppendLine("-----------------------------------------------------------------------");
            }
            return sb.ToString();
        }

    }   
}