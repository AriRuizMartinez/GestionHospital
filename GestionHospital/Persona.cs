using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }

        public Persona() { }
        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
    }
}
