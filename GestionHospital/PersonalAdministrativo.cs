using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class PersonalAdministrativo : PersonalHospital
    {
        public PersonalAdministrativo() { }
        public PersonalAdministrativo(string nombre, int edad, int sueldo) : base(nombre, edad, sueldo) { }

        public override string ToString()
        {
            return $"Personal administrativo: Nombre: {Nombre}, Edad: {Edad}, Sueldo: {Sueldo}";
        }
    }
}
