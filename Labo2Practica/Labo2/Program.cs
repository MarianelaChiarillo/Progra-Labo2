using ClaseNegocio;
using ClasesNegocio;

namespace claseLabo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Compañia compañiaMovistar = new Compañia("Movistar");


            Celular celular = new Celular(EMarca.Xiaomi, $"Modelo:", 8, 128);
            Celular celular2 = new Celular(EMarca.Samsung, $"Modelo:", 16, 64);
            Celular celular3 = new Celular(EMarca.Motorola, $"Modelo:", 4, 16);

            Contacto contactoM = new Contacto("Monica", "1130553377");
            Contacto contactoE = new Contacto("Enri", "1123456657");
            Contacto contactoZ = new Contacto("Zulm", "125678993");


            celular.Agenda1.Add(contactoE, DateTime.Now);
            celular2.Agenda1.Add(contactoM, DateTime.Now);
            celular3.Agenda1.Add(contactoZ, DateTime.Now);


            App appJuegos = new App("X", 2);
            App appVideos = new App("Youtube", 3);
            App appMusica = new App("Spotify", 1);
            App appSocial = new App("Telegram", 5);
            App appInsta = new App("Instagram", 3);

                
            celular.Apps1.Add(appJuegos);
            celular.Apps1.Add(appVideos);
            celular2.Apps1.Add(appMusica);
            celular3.Apps1.Add(appSocial);
            celular3.Apps1.Add(appInsta);

            compañiaMovistar.PilaDeCelus.Push(celular);
            compañiaMovistar.PilaDeCelus.Push(celular2);
            compañiaMovistar.PilaDeCelus.Push(celular3);



            Console.WriteLine("INFORMACION DE LA COMPAÑIA Y  CELULARES");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(compañiaMovistar.MostrarCompañia());

            Console.WriteLine("Registro Xiaomi: ");
            celular.AlternarEncendido();
            celular.Llamar(contactoE);

            Console.WriteLine("Registro Samsung: ");
            celular2.AlternarEncendido();
            celular2.Llamar(contactoM);

            Console.WriteLine("Registro Motorola: ");
            celular3.AlternarEncendido();
            celular3.Llamar(contactoZ);
            celular3.Llamar("116057444");


        }


    }
}
