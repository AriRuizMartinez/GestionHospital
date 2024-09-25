using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    /// <summary>
    /// Clase publica que gestiona la informacion de un medico
    /// </summary>
    public class Medico : PersonalHospital
    {
        public List<Paciente> Pacientes { get; set; }
        public Especialidad Especialidad { get; set; }

        public Medico() : base()
        {
            Pacientes = new List<Paciente>();
        }
        public Medico(string nombre, int edad, int sueldo, Especialidad especialidad) : base(nombre, edad, sueldo)
        {
            Pacientes = new List<Paciente>();
            Especialidad = especialidad;
        }

        /// <summary>
        /// Metodo que añade un paciente
        /// </summary>
        public void AñadirPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        /// <summary>
        /// Metodo que elimina un paciente
        /// </summary>
        public void EliminarPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        /// <summary>
        /// Metodo que muestra los pacientes de este medico
        /// </summary>
        public void MostrarMisPacientes()
        {
            foreach (Paciente p in Pacientes)
                Console.WriteLine(p.ToString());
        }
        public override string ToString()
        {
            return $"Medico: Nombre: {Nombre}, Edad: {Edad}, Sueldo: {Sueldo}, Especialidad: {Especialidad}";
        }
    }

    /// <summary>
    /// Enum que define las especialidades que puede tener un medico
    /// </summary>
    public enum Especialidad
    {
        Cardiologia = 1,
        Pediatria = 2,
        Dermatologia = 3,
        Geriatria = 4,
        Urologia = 5
    }
}
