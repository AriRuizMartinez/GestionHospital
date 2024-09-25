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
        /// Metodo principal de la aplicacion que se ejecuta al comenzar el programa y llama a la gestion del hospital
        /// </summary>
        /// <param name="args">Lista de argumentos para iniciar el metodo</param>
        static void Main(string[] args)
        {
            Hospital h = new Hospital();
            h.GestionDelHospital();
        }

        
    }
}