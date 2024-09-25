using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class Hospital
    {
        private List<Persona> personaList;

        public Hospital() 
        {
            personaList = new List<Persona>();
        }

        /// <summary>
        /// Metodo que inicializa los medicos para no tener problemas y gestiona la logica del menu
        /// </summary>
        public void GestionDelHospital()
        {
            personaList.Add(new Medico("Juan", 42, 2500, eEspecialidad.Cardiologia));
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
                        MostrarPersonaTipoConcreto(typeof(Medico));
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

        int Menu()
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
        private void NuevoMedico()
        {
            personaList.Add(new Medico(PedirNombre(), PedirEdad(24, 70), PedirSueldo(), PedirEspecialidad()));
        }


        /// <summary>
        /// Metodo que pide un nombre al usuario
        /// </summary>
        /// <returns>Devuelve el nombre que el usuario elija</returns>
        private string PedirNombre()
        {
            Console.WriteLine("Escribe el nombre.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que pide un numero al usuario y gestiona que este dentro de unos valores
        /// </summary>
        /// <param name="min">Valor minimo que debe cumplir la edad</param>
        /// <param name="max">Valor maximo que debe cumplir la edad</param>
        /// <returns>Devuelve el numero que el usuario elija</returns>
        private int PedirEdad(int min, int max)
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
        private int PedirSueldo()
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
        private eEspecialidad PedirEspecialidad()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────┐
│       MENU  PRINCIPAL      │
├────────────────────────────┤
│  (1)  - Cardiologia        │
│  (2)  - Pediatria          │
│  (3)  - Dermatologia       │
│  (4)  - Geriatria          │
│  (5)  - Urologia           │
└────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 1 || option > 5);

            return (eEspecialidad)option;
        }

        /// <summary>
        /// Metodo que genera un nuevo paciente pidiendo todos los parametros necesarios
        /// </summary>
        private void NuevoPaciente()
        {
            personaList.Add(new Paciente(PedirNombre(), PedirEdad(0, 120), PedirEnfermedad(), PedirMedico()));
        }

        /// <summary>
        /// Metodo que devuelve un medico seleccionado por el usuario
        /// </summary>
        /// <returns>Devuelve el medico que el usuario elija</returns>
        private Medico PedirMedico()
        {
            MostrarPersonaTipoConcreto(typeof(Medico));
            return (Medico)EncontrarPersona(typeof(Medico));
        }

        /// <summary>
        /// Metodo que pide un nombre al usuario para seleccionar una persona
        /// </summary>
        /// <param name="tipo">Tipo que debe cumplir la persona</param>
        /// <returns>Devuelve la persona que el usuario elija</returns>
        private Persona EncontrarPersona(Type tipo)
        {
            Console.WriteLine("Escribe el nombre de la persona que quieres.");
            while (true)
            {
                string nombre = Console.ReadLine();
                Persona p = personaList.Where(persona => persona.Nombre == nombre && tipo.IsInstanceOfType(persona)).FirstOrDefault();
                if(p != null)
                    return p;
                Console.WriteLine("Ese nombre no existe para el tipo de persona que estas buscando.");
            }
        } 

        /// <summary>
        /// Metodo que pide una enfermedad al usuario
        /// </summary>
        /// <returns>Devuelve la enfermedad que el usuario elija</returns>
        private string PedirEnfermedad()
        {
            Console.WriteLine("Que enfermedad tiene?");
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que genera un nuevo personal administrativo pidiendo todos los parametros necesarios
        /// </summary>
        private void NuevoAdministrativo()
        {
            personaList.Add(new PersonalAdministrativo(PedirNombre(), PedirEdad(18, 75), PedirSueldo(), PedirDepartamento()));
        }

        /// <summary>
        /// Metodo que pide un departamento al usuario
        /// </summary>
        /// <returns>Devuelve el departamento que el usuario elija</returns>
        private eDepartamento PedirDepartamento()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────┐
│       MENU  PRINCIPAL      │
├────────────────────────────┤
│  (1)  - Recepcion          │
│  (2)  - Recursos Humanos   │
│  (3)  - Finanzas           │
│  (4)  - Legal              │
│  (5)  - Logistica          │
└────────────────────────────┘
");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 1 || option > 5);

            return (eDepartamento)option;
        }

        /// <summary>
        /// Metodo que muestra las personas del tipo pasado por parametro
        /// </summary>
        /// /// <param name="tipo">Tipo debe cumplir la persona para ser listada</param>
        private void MostrarPersonaTipoConcreto(Type tipo)
        {
            Console.WriteLine("");
            List<Persona> personasTipo = personaList.Where(persona => tipo.IsInstanceOfType(persona)).ToList();
            foreach (Persona persona in personasTipo)
                Console.WriteLine(persona.ToString() );
        }

        /// <summary>
        /// Metodo que muestra los pacientes de un medico concreto
        /// </summary>
        private void MostrarPacientesDeUnMedico()
        {
            MostrarPersonaTipoConcreto(typeof(Medico));
            ( (Medico) EncontrarPersona( typeof(Medico) ) ).MostrarMisPacientes();
        }

        /// <summary>
        /// Metodo que elimina al paciente que el usuario escoga
        /// </summary>
        private void EliminarPaciente()
        {
            MostrarPersonaTipoConcreto(typeof(Paciente));
            Console.WriteLine("Que paciente quieres eliminar?");
            Paciente p = (Paciente) EncontrarPersona(typeof(Paciente));

            personaList.Remove(p);
            p.QuitarDePacienteDeMiMedico();
        }

        /// <summary>
        /// Metodo que muestra todas la personas del hospital, desde medicos a pacientes pasando por personal administrativo
        /// </summary>
        private void MostrarPersonas()
        {
            foreach(Persona persona in personaList)
                Console.WriteLine(persona.ToString());
        }
    }
}
