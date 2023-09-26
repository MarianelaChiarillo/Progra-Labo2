
using ClaseNegocio;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClasesNegocio
{
    public class Celular
    {

        #region Atributos

        private EMarca marca;
        private string modelo;
        private int ram;
        private double almacenamiento;
        private double almacenamientoActual;
        private bool encendido;
        private string titular;
        private string numero;
        private Dictionary<Contacto, DateTime> Agenda;//Lista Contacto
        private List<App> apps;//Lista App
        private Queue<Llamada> llamadasRealizadas;

        #endregion


        #region Constructores
        public Celular(EMarca marca, string modelo, int ram, double almacenamiento, List<Contacto> agenda) : this(marca, modelo, ram, almacenamiento)
        {
            this.Agenda = agenda.ToDictionary(Contacto => Contacto, _ => DateTime.Now);
        }

        public Celular(EMarca marca, string modelo, int ram, double almacenamiento) : this()
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ram = ram;
            this.Almacenamiento = almacenamiento;
            this.Encendido = false;
            this.AlmacenamientoActual = 0;
        }

        public Celular()
        {
            this.apps = new List<App>();
            this.Agenda = new Dictionary<Contacto, DateTime>();
            this.llamadasRealizadas = new Queue<Llamada>();
        }
        #endregion


        #region Propiedades



        public string Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }

        public EMarca Marca { get => marca; set => marca = value; }

        public int Ram { get => ram; set => ram = value; }
        public double Almacenamiento
        {
            get => almacenamiento;
            set => almacenamiento = value;
        }
        public double AlmacenamientoActual { get => almacenamientoActual; set => almacenamientoActual = value; }
        public bool Encendido { get => encendido; set => encendido = value; }
        public Dictionary<Contacto, DateTime> Agenda1 { get => Agenda; set => Agenda = value; }
        public List<App> Apps1 { get => apps; set => apps = value; }
        public Queue<Llamada> LlamadasRealizadas { get => llamadasRealizadas; set => llamadasRealizadas = value; }
        public string Titular { get => titular; set => titular = value; }
        public string Numero { get => numero; set => numero = value; }


        #endregion


        #region Metodos Instancia
        public string AlternarEncendido()
        {

            this.Encendido = !this.Encendido;

            return this.Encendido ? "Encendiendo..." : "Apagando...";



            //string mensaje;
            //if(this.encendido == true)
            //{
            //    this.encendido = false;
            //    mensaje = "Apagando...";
            //}
            //else
            //{
            //    this.encendido = true;
            //    mensaje = "Encendiendo...";
            //}


            //return mensaje;
        }

        public void Llamar(string numero)
        {
            //Encendido
            if (this.encendido)
            {
                if (BuscarEnAgenda(numero))
                {
                    Console.WriteLine($"Llamando al numero: {numero}");
                    Llamada llamada = new Llamada(DateTime.Now, numero, 0);
                    llamadasRealizadas.Enqueue(llamada);

                }
                else
                {
                    Console.WriteLine("Numero no encontrado...");
                }
            }
            else
            {
                Console.WriteLine("El celular esta apagado");
            }
            //El numero tiene que estar agendado
        }

        public void Llamar(Contacto unContacto)
        {
            if (this.encendido)
            {
                if (BuscarEnAgenda(unContacto.numero))
                {
                    Console.WriteLine($"Llamando a: {unContacto.nombre}");
                    Llamada llamada = new Llamada(DateTime.Now, unContacto.numero, 5);
                    llamadasRealizadas.Enqueue(llamada);
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado...");
                }
            }
            else
            {
                Console.WriteLine("El celular esta apagado");
            }
        }


        private bool BuscarEnAgenda(string numeroIngresado)
        {
            bool estaEnAgenda = false;

            foreach (var kvp in this.Agenda)
            {
                if (kvp.Key.numero == numeroIngresado)
                {
                    estaEnAgenda = true;
                    break;
                }
            }

            return estaEnAgenda;
        }

        private bool InstalarApp(App aplicacion)
        {
            bool exito = false;

            if (this.encendido && this != aplicacion && VerificarEspacio(aplicacion.Size))
            {
                exito = true;
                this.apps.Add(aplicacion);
                this.almacenamientoActual += aplicacion.Size;
            }
            //Encendido
            //app no este instalada
            //haya espacio


            return exito;
        }

        private bool VerificarEspacio(double nuevoSize)
        {
            return (this.almacenamientoActual + nuevoSize) < this.almacenamiento;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Marca: {this.marca}");
            sb.AppendLine($"Modelo: {this.modelo}");
            sb.AppendLine($"RAM: {this.ram}");
            sb.AppendLine($"Almacenamiento: {this.almacenamiento}");
            sb.AppendLine("Aplicaciones instaladas");
            if (this.apps.Count > 0)
            {
                foreach (App aplicacion in apps)
                {
                    sb.AppendLine($"\t{aplicacion.Nombre}");
                }
            }
            else
            {
                sb.AppendLine("No hay apps instaladas");
            }
            sb.AppendLine("*******************************************");
            return sb.ToString();
        }

        #endregion


        #region Sobrecarga de operadores
        public static bool operator ==(Celular miCelu, App miApp)
        {
            return miCelu.apps.Contains(miApp);
        }
        public static bool operator !=(Celular miCelu, App miApp)
        {
            return !(miCelu == miApp);
        }

        public static bool operator +(Celular miCelu, App miApp)
        {
            return miCelu.InstalarApp(miApp);
        }
        #endregion







    }
}