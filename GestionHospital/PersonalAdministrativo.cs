using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    /// <summary>
    /// Clase publica que gestiona la informacion de un personal administrativo
    /// </summary>
    public class PersonalAdministrativo : PersonalHospital
    {
        public Departamento Departamento { get; set; }
        public PersonalAdministrativo() { }
        public PersonalAdministrativo(string nombre, int edad, int sueldo, Departamento departamento) : base(nombre, edad, sueldo) 
        {
            Departamento = departamento;
        }

        public override string ToString()
        {
            return $"Personal administrativo: Nombre: {Nombre}, Edad: {Edad}, Sueldo: {Sueldo}, Departamento: {Departamento}";
        }
    }

    /// <summary>
    /// Enum que define los departamentos que puede tener un personal administrativo
    /// </summary>
    public enum Departamento
    {
        Recepcion = 1,
        RecursosHumanos = 2,
        Finanzas = 3,
        Legal = 4,
        Logistica = 5
    }
}
