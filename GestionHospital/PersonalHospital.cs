using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    /// <summary>
    /// Clase abstracta publica que gestiona la informacion de un personal del hospital
    /// </summary>
    public abstract class PersonalHospital : Persona
    {
        public int Sueldo {  get; set; }

        public PersonalHospital() : base() { }

        public PersonalHospital(string nombre, int edad, int sueldo) : base(nombre, edad)
        {
            Sueldo = sueldo;
        }
    }
}
