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
        //Variable que gestiona los pacientes del hospital
        static List<Paciente> pacientes = new List<Paciente>();
        //Variable que gestiona los medicos del hospital
        static List<Medico> medicos = new List<Medico>();
        //Variable que gestiona el personal administrativo del hospital
        static List<PersonalAdministrativo> personalAdministrativos = new List<PersonalAdministrativo>();

        /// <summary>
        /// Metodo principal de la aplicacion que se ejecuta al comenzar el programa y llama a la gestion del hospital
        /// </summary>
        /// <param name="args">Lista de argumentos para iniciar el metodo</param>
        static void Main(string[] args)
        {
            GestionDelHospital();
        }

        /// <summary>
        /// Metodo que inicializa los medicos para no tener problemas y gestiona la logica del menu
        /// </summary>
        private static void GestionDelHospital()
        {
            medicos.Add(new Medico("Juan", 42, 2500, Especialidad.Cardiologia));
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
                        MostrarPacientesDeUnMedico();
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

        /// <summary>
        /// Metodo que genera un nuevo medico pidiendo todos los parametros necesarios
        /// </summary>
        private static void NuevoMedico()
        {
            medicos.Add(new Medico(PedirNombre(), PedirEdad(24, 70), PedirSueldo(), PedirEspecialidad()));
        }


        /// <summary>
        /// Metodo que pide un nombre al usuario
        /// </summary>
        /// <returns>Devuelve el nombre que el usuario elija</returns>
        private static string PedirNombre()
        {
            Console.WriteLine("Escribe el nombre.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que pide un numero al usuario y gestiona que este dentro de unos valores
        /// </summary>
        /// /// <param name="min">Valor minimo que debe cumplir la edad</param>
        /// /// <param name="max">Valor maximo que debe cumplir la edad</param>
        /// <returns>Devuelve el numero que el usuario elija</returns>
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

        /// <summary>
        /// Metodo que pide un sueldo al usuario
        /// </summary>
        /// <returns>Devuelve el sueldo que el usuario elija</returns>
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

        /// <summary>
        /// Metodo que pide una especialidad al usuario
        /// </summary>
        /// <returns>Devuelve la especialidad que el usuario elija</returns>
        private static Especialidad PedirEspecialidad()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────┐
│       MENU  PRINCIPAL      │
├────────────────────────────┤
│  (1)  - Cardiologia        │
│  (4)  - Pediatria          │
│  (2)  - Dermatologia       │
│  (3)  - Geriatria          │
│  (5)  - Urologia           │
└────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 1 || option > 5);

            return (Especialidad) option;
        }

        /// <summary>
        /// Metodo que genera un nuevo paciente pidiendo todos los parametros necesarios
        /// </summary>
        private static void NuevoPaciente()
        {
            pacientes.Add(new Paciente(PedirNombre(), PedirEdad(0, 120), PedirEnfermedad(), PedirMedico()));
        }

        /// <summary>
        /// Metodo que devuelve un medico seleccionado por el usuario
        /// </summary>
        /// <returns>Devuelve el medico que el usuario elija</returns>
        private static Medico PedirMedico()
        {
            MostrarMedicos();
            int indice = PedirIndice(medicos.Count);
            return medicos[indice];
        }

        /// <summary>
        /// Metodo que pide un indice al usuario respecto a una lista y gestiona que los valores sean acepatables
        /// </summary>
        /// /// <param name="largoDeLaLista">Valor maximo excluyente que debe cumplir el indice</param>
        /// <returns>Devuelve el indice que el usuario elija</returns>
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

        /// <summary>
        /// Metodo que pide una enfermedad al usuario
        /// </summary>
        /// <returns>Devuelve la enfermedad que el usuario elija</returns>
        private static string PedirEnfermedad()
        {
            Console.WriteLine("Que enfermedad tiene?");
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que genera un nuevo personal administrativo pidiendo todos los parametros necesarios
        /// </summary>
        private static void NuevoAdministrativo()
        {
            personalAdministrativos.Add(new PersonalAdministrativo(PedirNombre(), PedirEdad(18, 75), PedirSueldo(), PedirDepartamento()));
        }

        /// <summary>
        /// Metodo que pide un departamento al usuario
        /// </summary>
        /// <returns>Devuelve el departamento que el usuario elija</returns>
        private static Departamento PedirDepartamento()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────┐
│       MENU  PRINCIPAL      │
├────────────────────────────┤
│  (1)  - Recepcion          │
│  (4)  - Recursos Humanos   │
│  (2)  - Finanzas           │
│  (3)  - Legal              │
│  (5)  - Logistica          │
└────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 1 || option > 5);

            return (Departamento)option;
        }

        /// <summary>
        /// Metodo que muestra los medicos
        /// </summary>
        private static void MostrarMedicos()
        {
            Console.WriteLine("");
            foreach (Medico m in medicos)
                Console.WriteLine(m.ToString());
        }

        /// <summary>
        /// Metodo que muestra los pacientes de un medico concreto
        /// </summary>
        private static void MostrarPacientesDeUnMedico()
        {
            MostrarMedicos();
            int indice = PedirIndice(medicos.Count);
            medicos[indice].MostrarMisPacientes();
        }

        /// <summary>
        /// Metodo que elimina al paciente que el usuario escoga
        /// </summary>
        private static void EliminarPaciente()
        {
            MostrarPacientes();
            Console.WriteLine("Que paciente quieres eliminar?");
            int indice = PedirIndice(pacientes.Count);
            Paciente p = pacientes[indice];

            pacientes.Remove(p);
            p.QuitarDePacienteDeMiMedico();
        }

        /// <summary>
        /// Metodo que muestra todas la personas del hospital, desde pacientes a medicos pasando por personal administrativo
        /// </summary>
        private static void MostrarPersonas()
        {
            MostrarPacientes();
            MostrarMedicos();
            MostrarPersonalAdministrativo();
        }

        /// <summary>
        /// Metodo que muestra todos los pacientes del hospital
        /// </summary>
        private static void MostrarPacientes()
        {
            Console.WriteLine("");
            foreach (Paciente p in pacientes)
                Console.WriteLine(p.ToString());
        }

        /// <summary>
        /// Metodo que muestra todos el personal administrativo del hospital
        /// </summary>
        private static void MostrarPersonalAdministrativo()
        {
            Console.WriteLine("");
            foreach (PersonalAdministrativo p in personalAdministrativos)
                Console.WriteLine(p.ToString());
        }
    }
}