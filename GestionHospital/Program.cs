using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    /// <summary>
    /// Clase interna que gestiona toda nuestra aplicacion
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Metodo principal de la aplicacion que se ejecuta al comenzar el rpograma
        /// </summary>
        /// <param name="args">Lista de argumentos para iniciar el metodo</param>
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 0:
                        return;
                }
            }
        }

        /// <summary>
        /// Metodo que muestra el las opciones y gestiona la opcion que has elegido
        /// </summary>
        /// <returns>Devuelve la opcion del menu que el usuario elija</returns>
        static int Menu()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────────────────────────┐
│                 MENU  PRINCIPAL                │
├────────────────────────────────────────────────┤
│  (1)  - Dar de alta un medico                  │
│  (2)  - Dar de alta un paciente                │
│  (3)  - Dar de alta personal administrativo    │
│  (4)  - Listar los médicos                     │
│  (5)  - Listar los pacientes de un medico      │
│  (6)  - Eliminar a un paciente                 │
│  (7)  - Ver la lista de personas del hospital  │
│  (0)  - Salir                                  │
└────────────────────────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 7);

            return option;
        }


    }
}