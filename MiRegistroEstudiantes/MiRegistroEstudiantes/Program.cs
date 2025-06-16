using System;

namespace RegistroEstudiantes
{
    // Esta es mi clase principal para representar un estudiante
    public class Estudiante
    {
        // Decidí hacer las variables privadas para proteger los datos
        private int id;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string[] telefonos;

        // Constructor - aquí inicializo todo cuando creo un nuevo estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            // Creo el array para 3 teléfonos desde el inicio
            this.telefonos = new string[3];
        }

        // Properties para acceder a los datos - aprendí que es mejor práctica que variables públicas
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        // Este método me costó un poco de trabajo - tengo que validar la posición
        public bool AgregarTelefono(string telefono, int posicion)
        {
            // Verifico que la posición sea válida (0, 1 o 2)
            if (posicion >= 0 && posicion < telefonos.Length)
            {
                telefonos[posicion] = telefono;
                return true;
            }
            Console.WriteLine("Error: Posición inválida para teléfono");
            return false;
        }

        // Método para obtener un teléfono específico
        public string ObtenerTelefono(int posicion)
        {
            if (posicion >= 0 && posicion < telefonos.Length)
            {
                return telefonos[posicion] ?? "No asignado";
            }
            return "Posición inválida";
        }

        // Este método me permite ver todos los teléfonos de una vez
        public string[] ObtenerTodosTelefonos()
        {
            return telefonos;
        }

        // Función para mostrar toda la información - muy útil para debugging
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombre completo: {nombres} {apellidos}");
            Console.WriteLine($"Dirección: {direccion}");
            Console.WriteLine("Teléfonos:");

            // Recorro el array y solo muestro los teléfonos que están llenos
            for (int i = 0; i < telefonos.Length; i++)
            {
                if (!string.IsNullOrEmpty(telefonos[i]))
                {
                    Console.WriteLine($"  {i + 1}. {telefonos[i]}");
                }
                else
                {
                    Console.WriteLine($"  {i + 1}. No asignado");
                }
            }
            Console.WriteLine(); // Línea en blanco para separar
        }

        // Método que agregué para validar si el estudiante tiene datos completos
        public bool TieneDatosCompletos()
        {
            // Verifico que tenga nombre, apellido y dirección
            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) ||
                string.IsNullOrEmpty(direccion))
            {
                return false;
            }

            // Verifico que tenga al menos un teléfono
            bool tieneAlMenosUnTelefono = false;
            foreach (string tel in telefonos)
            {
                if (!string.IsNullOrEmpty(tel))
                {
                    tieneAlMenosUnTelefono = true;
                    break;
                }
            }

            return tieneAlMenosUnTelefono;
        }
    }

    // Clase adicional que creé para manejar varios estudiantes
    public class GestorEstudiantes
    {
        private Estudiante[] listaEstudiantes;
        private int contador;

        public GestorEstudiantes(int capacidadMaxima)
        {
            listaEstudiantes = new Estudiante[capacidadMaxima];
            contador = 0;
        }

        public bool RegistrarEstudiante(Estudiante nuevoEstudiante)
        {
            if (contador < listaEstudiantes.Length)
            {
                // Verifico que no exista ya un estudiante con el mismo ID
                for (int i = 0; i < contador; i++)
                {
                    if (listaEstudiantes[i].Id == nuevoEstudiante.Id)
                    {
                        Console.WriteLine("Error: Ya existe un estudiante con ese ID");
                        return false;
                    }
                }

                listaEstudiantes[contador] = nuevoEstudiante;
                contador++;
                Console.WriteLine("Estudiante registrado exitosamente");
                return true;
            }
            else
            {
                Console.WriteLine("Error: No hay más espacio para registrar estudiantes");
                return false;
            }
        }

        public Estudiante BuscarPorId(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (listaEstudiantes[i].Id == id)
                {
                    return listaEstudiantes[i];
                }
            }
            return null;
        }

        public void MostrarTodos()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            Console.WriteLine($"\n=== LISTA DE ESTUDIANTES REGISTRADOS ({contador}) ===\n");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Estudiante #{i + 1}:");
                listaEstudiantes[i].MostrarInformacion();
                Console.WriteLine(new string('-', 50));
            }
        }

        public int CantidadRegistrados()
        {
            return contador;
        }
    }

    // Programa principal donde pruebo todo
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MI SISTEMA DE REGISTRO DE ESTUDIANTES ===\n");

            // Creo el gestor con capacidad para 10 estudiantes
            GestorEstudiantes gestor = new GestorEstudiantes(10);

            // Pruebo creando algunos estudiantes
            Estudiante est1 = new Estudiante(12345, "Emilio Senguana", "Maria Senguana",
                                           "Los Ceibos, Mz. 15, Villa 8");
            est1.AgregarTelefono("04-2234567", 0);  // teléfono casa
            est1.AgregarTelefono("0991234567", 1);  // celular
            est1.AgregarTelefono("04-2345678", 2);  // trabajo

            Estudiante est2 = new Estudiante(12346, "Carlos Andrés", "Mendoza Ruiz",
                                           "Urdesa Central, Calle 3ra #405");
            est2.AgregarTelefono("0987654321", 0);
            est2.AgregarTelefono("04-2887766", 1);

            Estudiante est3 = new Estudiante(12347, "Sofía Isabel", "Vargas Torres",
                                           "Alborada 8va Etapa, Mz. 825, Villa 15");
            est3.AgregarTelefono("0995566778", 0);

            // Los registro en el sistema
            gestor.RegistrarEstudiante(est1);
            gestor.RegistrarEstudiante(est2);
            gestor.RegistrarEstudiante(est3);

            // Muestro todos los estudiantes
            gestor.MostrarTodos();

            // Pruebo la búsqueda
            Console.WriteLine("=== PRUEBA DE BÚSQUEDA ===");
            Estudiante encontrado = gestor.BuscarPorId(12346);
            if (encontrado != null)
            {
                Console.WriteLine("Estudiante encontrado:");
                encontrado.MostrarInformacion();
            }

            // Verifico datos completos
            Console.WriteLine("=== VERIFICACIÓN DE DATOS COMPLETOS ===");
            Console.WriteLine($"Est1 datos completos: {est1.TieneDatosCompletos()}");
            Console.WriteLine($"Est2 datos completos: {est2.TieneDatosCompletos()}");
            Console.WriteLine($"Est3 datos completos: {est3.TieneDatosCompletos()}");

            // Pruebo error al agregar teléfono en posición inválida
            Console.WriteLine("\n=== PRUEBA DE VALIDACIÓN ===");
            est1.AgregarTelefono("0999888777", 5); // Esto debería dar error

            Console.WriteLine($"\nTotal de estudiantes registrados: {gestor.CantidadRegistrados()}");

            Console.WriteLine("\nPresiona Enter para salir...");
            Console.ReadLine();
        }
    }
}