using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoFinal
{
    class Program
    {
        static StreamWriter escribirtxt;
        static StreamReader leertxt;
        //Archivo de texto = clientesInfo.txt;

        struct informacion
        {
            public String dui, nombre, nombreMascota, tratamiento, medicamento, costo;
            public int visita;
        }
        static void Main(string[] args)
        {
            string usuarioDefinido = "Veterinaria01";
            string usuarioIngresado = "";
            string contraseñaIngresada = "";
            string contraseñaDefinida = "1234";
            int opcion;


            Console.WriteLine("Digitar el usuario planteado en el manual de usuarios: ");
            usuarioIngresado = Console.ReadLine();

            Console.WriteLine("Digitar la contraseña planteada en el manual de usuarios: ");
            contraseñaIngresada = Console.ReadLine();

            if (usuarioDefinido == usuarioIngresado && contraseñaDefinida == contraseñaIngresada)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine("*              ¡Veterinaria de Lissette!             *");
                Console.WriteLine("*    Presione [ENTER] para continuar hacia el menú   *");
                Console.WriteLine("******************************************************");
                Console.ReadKey();
                Console.Clear();

                do
                {
                    Console.WriteLine("\n|---------------------------------------------|");
                    Console.WriteLine("|              Elija una opcion               |");
                    Console.WriteLine("|---------------------------------------------|");
                    Console.WriteLine("|    Digite el numero de la opcion deseada    |");
                    Console.WriteLine("|---------------------------------------------|");
                    Console.WriteLine("| 1 | Agregar información de un cliente       |");
                    Console.WriteLine("|                                             |");
                    Console.WriteLine("| 2 | Mostrar el registro de los clientes     |");
                    Console.WriteLine("|                                             |");
                    Console.WriteLine("| 3 | Buscar cliente por número de DUI        |");
                    Console.WriteLine("|                                             |");
                    Console.WriteLine("| 4 | Salir del programa                      |");
                    Console.WriteLine("|---------------------------------------------|");

                    opcion = Int32.Parse(Console.ReadLine());

                    if (opcion == 1) agregarClientes();
                    if (opcion == 2) mostrarClientes();
                    if (opcion == 3) buscarClientes();
                    if (opcion == 4)
                    {
                        Console.WriteLine("******************************************************");
                        Console.WriteLine("*              ¡Gracias por preferirnos!             *");
                        Console.WriteLine("*    Presione [ENTER] para finalizar el programa.    *");
                        Console.WriteLine("******************************************************");
                        Console.ReadKey();
                    }

                } while (opcion != 4);


            }
            else
            {
                Console.Clear();
                Console.WriteLine("Usuario y contraseñas invalidas. ¡Por favor intentar de nuevo!");
                Console.ReadKey();
            }
        }

        private static void agregarClientes()
        {
            Console.Clear();

            escribirtxt = new StreamWriter("clientesInformacion.txt", true);

            informacion p = new informacion();

            Console.WriteLine("\nEsriba un nombre y un apellido: ");
            p.nombre = Console.ReadLine();

            Console.WriteLine("\nDigite su número de DUI (Sin guión): ");
            p.dui = Console.ReadLine();

            Console.WriteLine("\nEsriba el nombre de su mascota: ");
            p.nombreMascota = Console.ReadLine();

            Console.WriteLine("\nEsriba el tratamiento que se brindó: ");
            p.tratamiento = Console.ReadLine();

            Console.WriteLine("\nEsriba la receta médica (medicamentos): ");
            p.medicamento = Console.ReadLine();

            Console.WriteLine("\nEsriba el costo final de los servicios realizados: ");
            p.costo = Console.ReadLine();

            Console.WriteLine("Número de visita: ");
            p.visita = Int32.Parse(Console.ReadLine());

            if (p.visita >= 4 && p.visita <8)
            {
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("*¡Se le ha asignado un 5% de descuento al cliente por su preferencia!*");
                Console.WriteLine("*          Realizar el descuento al costo final manualmente          *");
                Console.WriteLine("**********************************************************************");
            }
            else if (p.visita >= 8)
            {
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("*¡Se le ha asignado un 8% de descuento al cliente por su preferencia!*");
                Console.WriteLine("*          Realizar el descuento al costo final manualmente          *");
                Console.WriteLine("**********************************************************************");
            }
                

            Console.ReadKey();
            Console.Clear();

            String registro = $"{p.nombre},{p.dui},{p.nombreMascota},{p.tratamiento},{p.medicamento},{p.costo},{p.visita}";

            escribirtxt.WriteLine(registro);
            escribirtxt.Close();
        }

        private static void mostrarClientes()
        {
            Console.Clear();

            leertxt = new StreamReader("clientesInformacion.txt", true);
            String registro = "";
            char[] caracter = new char[1];
            caracter[0] = ',';

            while ((registro = leertxt.ReadLine()) != null)
            {
                String[] datos = registro.Split(caracter);
                Console.WriteLine("********************************");
                Console.WriteLine($"NOMBRE DEL CLIENTE : {datos[0]}");
                Console.WriteLine($"DUI DEL CLIENTE : {datos[1]}");
                Console.WriteLine($"NOMBRE DE LA MASCOTA : {datos[2]}");
                Console.WriteLine($"TRATAMIENTO : {datos[3]}");
                Console.WriteLine($"MEDICAMENTO : {datos[4]}");
                Console.WriteLine($"COSTO : {datos[5]}");
                Console.WriteLine($"VISITA : {datos[6]}");
                Console.WriteLine("********************************");
                Console.ReadKey();
            }
            Console.Clear();
            leertxt.Close();
        }

        private static void buscarClientes()
        {
            Console.Clear();
            
            leertxt = new StreamReader("clientesInformacion.txt", true);
            String registro = "";
            char[] caracter = new char[1];
            caracter[0] = ',';
            String newdui = "";
            Console.WriteLine("Digite DUI a buscar:");
            newdui = Console.ReadLine();
            bool encontro = false;
            while ((registro = leertxt.ReadLine()) != null)
            {
                String[] datos = registro.Split(caracter);
                if (newdui == datos[1])
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("* REGISTRO ENCONTRADO *");
                    Console.WriteLine($"NOMBRE : {datos[0]}");
                    Console.WriteLine($"DUI : {datos[1]}");
                    Console.WriteLine($"MASCOTA : {datos[2]}");
                    Console.WriteLine($"TRATAMIENTO : {datos[3]}");
                    Console.WriteLine($"MEDICAMENTO : {datos[4]}");
                    Console.WriteLine($"COSTOS : {datos[5]}");
                    Console.WriteLine($"VISITA : {datos[6]}");
                    Console.WriteLine("****************************");
                    encontro = true;
                    Console.ReadKey();
                    
                }

            }
            if (encontro == false)
            {
                Console.WriteLine("\n****************************");
                Console.WriteLine("*  REGISTRO NO ENCONTRADO  *");
                Console.WriteLine("****************************");
                Console.ReadKey();
            }
            leertxt.Close();
        }
    }
}