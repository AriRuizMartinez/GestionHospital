using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class Paciente : Persona
    {
        public string Enfermedad {  get; set; }
        public Medico Medico { get; set; }
        public Paciente() { }
        public Paciente(string nombre, int edad, string enfermedad, Medico medico) : base(nombre, edad)
        {
            Enfermedad = enfermedad;
            Medico = medico;
        }

        public override string ToString()
        {
            return $"Paciente: Nombre: {Nombre}, Edad: {Edad}, Enfermedad: {Enfermedad}, Medico: {Medico}";
        }
    }
}
