using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    /// <summary>
    /// Clase publica que gestiona la informacion de un paciente
    /// </summary>
    public class Paciente : Persona
    {
        public string Enfermedad {  get; set; }
        public Medico medico;
        public Medico Medico 
        { 
            get { return medico; } 
            set 
            {
                if (medico != null)
                    medico.EliminarPaciente(this);
                medico = value;
                if (medico != null) 
                    medico.AñadirPaciente(this);
            }
        }
        public Paciente() { }
        public Paciente(string nombre, int edad, string enfermedad, Medico medico) : base(nombre, edad)
        {
            Enfermedad = enfermedad;
            Medico = medico;
            medico.AñadirPaciente(this);
        }

        public override string ToString()
        {
            return $"Paciente: Nombre: {Nombre}, Edad: {Edad}, Enfermedad: {Enfermedad}, {Medico}";
        }

        /// <summary>
        /// Metodo que avisa al medico de que deja de ser su paciente
        /// </summary>
        public void QuitarDePacienteDeMiMedico()
        {
            Medico.EliminarPaciente(this);
        }
    }
}
