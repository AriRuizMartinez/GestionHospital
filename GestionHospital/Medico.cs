﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class Medico : PersonalHospital
    {
        public List<Paciente> Pacientes { get; set; }

        public Medico() : base()
        {
            Pacientes = new List<Paciente>();
        }

        public void AñadirPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void EliminarPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        public Medico(string nombre, int edad, int sueldo) : base(nombre, edad, sueldo)
        {
            Pacientes = new List<Paciente>();
        }

        public void MostrarMisPacientes()
        {
            foreach (Paciente p in Pacientes)
                Console.WriteLine(p.ToString());
        }
        public override string ToString()
        {
            return $"Medico: Nombre: {Nombre}, Edad: {Edad}, Sueldo: {Sueldo}";
        }
    }
}
