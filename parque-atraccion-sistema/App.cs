
namespace parque_atraccion_sistema;

public class App
{
    public static void Start()
    {
        GestorAtraccion gestor = new GestorAtraccion();
        bool continuar = true;

        Console.WriteLine("=== SISTEMA DE GESTIÓN DE ATRACCIÓN ===");
        Console.WriteLine("Parque de Diversiones - Capacidad: 30 asientos");
        Console.WriteLine("==========================================");

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarPersona(gestor);
                    break;
                case "2":
                    ProcesarSiguiente(gestor);
                    break;
                case "3":
                    gestor.MostrarEstadoCola();
                    break;
                case "4":
                    gestor.MostrarAsientosOcupados();
                    break;
                case "5":
                    gestor.MostrarResumen();
                    break;
                case "6":
                    BuscarPersona(gestor);
                    break;
                case "7":
                    gestor.ReiniciarSesion();
                    break;
                case "8":
                    continuar = false;
                    Console.WriteLine("Gracias por usar el sistema.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar persona a la cola");
        Console.WriteLine("2. Procesar siguiente en la cola");
        Console.WriteLine("3. Mostrar estado de la cola");
        Console.WriteLine("4. Mostrar asientos ocupados");
        Console.WriteLine("5. Mostrar resumen general");
        Console.WriteLine("6. Buscar persona");
        Console.WriteLine("7. Reiniciar sesión");
        Console.WriteLine("8. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarPersona(GestorAtraccion gestor)
    {
        Console.WriteLine("\n=== AGREGAR PERSONA ===");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Identificación: ");
        string identificacion = Console.ReadLine();

        Console.Write("Edad: ");
        if (int.TryParse(Console.ReadLine(), out int edad))
        {
            Persona persona = new Persona(nombre, identificacion, edad);
            if (gestor.AgregarPersonaACola(persona))
            {
                Console.WriteLine($"Persona agregada exitosamente. Posición en cola: {gestor.PersonasEnCola()}");
            }
            else
            {
                Console.WriteLine("Error: No hay espacio disponible en la atracción.");
            }
        }
        else
        {
            Console.WriteLine("Error: Edad inválida.");
        }
    }

    static void ProcesarSiguiente(GestorAtraccion gestor)
    {
        Console.WriteLine("\n=== PROCESAR SIGUIENTE ===");
        if (gestor.ProcesarSiguienteEnCola())
        {
            Console.WriteLine("Persona procesada y asiento asignado exitosamente.");
        }
        else
        {
            Console.WriteLine("Error: No hay personas en cola o no hay asientos disponibles.");
        }
    }

    static void BuscarPersona(GestorAtraccion gestor)
    {
        Console.WriteLine("\n=== BUSCAR PERSONA ===");
        Console.Write("Ingrese la identificación: ");
        string identificacion = Console.ReadLine();
        gestor.BuscarPersona(identificacion);
    }
}