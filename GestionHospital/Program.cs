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
        static List<Paciente> pacientes = new List<Paciente>();
        static List<Medico> medicos = new List<Medico>();
        static List<PersonalAdministrativo> personalAdministrativos = new List<PersonalAdministrativo>();

        /// <summary>
        /// Metodo principal de la aplicacion que se ejecuta al comenzar el programa y llama a la gestion del hospital
        /// </summary>
        /// <param name="args">Lista de argumentos para iniciar el metodo</param>
        static void Main(string[] args)
        {
            GestionDelHospital();
        }

        private static void GestionDelHospital()
        {
            medicos.Add(new Medico("Juan", 42, 2500));
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        NuevoMedico();
                        break;
                    case 2:
                        NuevoPaciente();
                        break;
                    case 3:
                        NuevoAdministrativo();
                        break;
                    case 4:
                        MostrarMedicos();
                        break;
                    case 5:
                        MostrarPacientes();
                        break;
                    case 6:
                        EliminarPaciente();
                        break;
                    case 7:
                        MostrarPersonas();
                        break;
                    case 0:
                        return;
                }
            }
        }

        /// <summary>
        /// Metodo que muestra el las opciones y gestiona la opcion que has elegido
        /// </summary>
        /// <returns>Devuelve la opcion del menu que el usuario elija</returns>

        static int Menu()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────────────────────────┐
│                 MENU  PRINCIPAL                │
├────────────────────────────────────────────────┤
│  (1)  - Dar de alta un medico                  │
│  (2)  - Dar de alta un paciente                │
│  (3)  - Dar de alta personal administrativo    │
│  (4)  - Listar los médicos                     │
│  (5)  - Listar los pacientes de un medico      │
│  (6)  - Eliminar a un paciente                 │
│  (7)  - Ver la lista de personas del hospital  │
│  (0)  - Salir                                  │
└────────────────────────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 7);

            return option;
        }
        private static void NuevoMedico()
        {
            string nombre = PedirNombre();
            int edad = PedirEdad(24, 70);
            int sueldo = PedirSueldo();

            medicos.Add(new Medico(nombre, edad, sueldo));
        }

        private static string PedirNombre()
        {
            Console.WriteLine("Escribe el nombre.");
            return Console.ReadLine();
        }
        private static int PedirEdad(int min, int max)
        {
            Console.WriteLine("Escribe la edad.");
            int edad;
            while (!int.TryParse(Console.ReadLine(), out edad))
                Console.WriteLine("Introduce un numero valido.");
            if (edad < min)
                edad = min;
            else if (edad > max)
                edad = max;
            return edad;
        }

        private static int PedirSueldo()
        {
            Console.WriteLine("Escribe el sueldo.");
            int sueldo;
            while (!int.TryParse(Console.ReadLine(), out sueldo))
                Console.WriteLine("Introduce un numero valido.");

            if (sueldo < 1800)
                sueldo = 1800;
            return sueldo;
        }

        private static void NuevoPaciente()
        {
            string nombre = PedirNombre();
            int edad = PedirEdad(0, 120);
            string enfermedad = PedirEnfermedad();
            Medico medico = PedirMedico();
            pacientes.Add(new Paciente(nombre, edad, enfermedad, medico));
        }

        private static Medico PedirMedico()
        {
            MostrarMedicos();
            int indice = PedirIndice(medicos.Count);
            return medicos[indice];
        }

        private static int PedirIndice(int largoDeLaLista)
        {
            Console.WriteLine("Escribe un numero que represente a la persona que quieres.");
            int indice;
            while (!int.TryParse(Console.ReadLine(), out indice))
                Console.WriteLine("Introduce un numero valido.");
            ++indice;
            if (indice < 0)
                indice = 0;
            else if (indice >= largoDeLaLista)
                indice = largoDeLaLista - 1;
            return indice;
        }

        private static string PedirEnfermedad()
        {
            Console.WriteLine("Que enfermedad tiene?");
            return Console.ReadLine();
        }

        private static void NuevoAdministrativo()
        {
            string nombre = PedirNombre();
            int edad = PedirEdad(18, 75);
            int sueldo = PedirSueldo();

            personalAdministrativos.Add(new PersonalAdministrativo(nombre, edad, sueldo));
        }

        private static void MostrarMedicos()
        {
            foreach(Medico m in medicos)
                Console.WriteLine(m.ToString());
        }

        private static void MostrarPacientes()
        {
            MostrarMedicos();
            int indice = PedirIndice(medicos.Count);
            medicos[indice].MostrarMisPacientes();
        }

        private static void EliminarPaciente()
        {
            MostrarPacientes();
            Console.WriteLine("Que paciente quieres eliminar?");
            int indice = PedirIndice(pacientes.Count);
            Paciente p = pacientes[indice];

            pacientes.Remove(p);
            p.QuitarDePacienteDeMiMedico();
        }

        private static void MostrarPersonas()
        {
            MostrarPacientes();
            MostrarMedicos();
            MostrarPersonalAdministrativo();
        }
        private static void MostrarPersonalAdministrativo()
        {
            foreach (PersonalAdministrativo p in personalAdministrativos)
                Console.WriteLine(p.ToString());
        }
    }
}