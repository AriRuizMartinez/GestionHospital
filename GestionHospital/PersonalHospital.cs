using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
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
