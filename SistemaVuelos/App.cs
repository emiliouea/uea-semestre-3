
public class App
{
    private GrafoVuelos _sistemaVuelos;

    public App()
    {
        _sistemaVuelos = InicializarSistema();
    }

    public void Ejecutar()
    {
        MostrarMenuPrincipal();
    }

    private GrafoVuelos InicializarSistema()
    {
        var grafo = new GrafoVuelos();

        Console.WriteLine("------------------------------------------------------\n");
        Console.WriteLine("   SISTEMA DE BÚSQUEDA DE VUELOS BARATOS              ");
        Console.WriteLine("   Universidad Estatal Amazónica                      ");
        Console.WriteLine("   Estructura de Datos - Práctica #04                 ");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("\n⏳ Cargando base de datos de vuelos...\n");

        // Base de datos ficticia de vuelos
        grafo.AgregarVuelo("Quito", "Guayaquil", 120);
        grafo.AgregarVuelo("Quito", "Cuenca", 150);
        grafo.AgregarVuelo("Quito", "Bogotá", 200);
        grafo.AgregarVuelo("Quito", "Lima", 250);
        grafo.AgregarVuelo("Guayaquil", "Lima", 220);
        grafo.AgregarVuelo("Guayaquil", "Bogotá", 280);
        grafo.AgregarVuelo("Cuenca", "Guayaquil", 100);
        grafo.AgregarVuelo("Cuenca", "Lima", 180);
        grafo.AgregarVuelo("Bogotá", "Ciudad de Panamá", 250);
        grafo.AgregarVuelo("Lima", "Ciudad de Panamá", 300);
        grafo.AgregarVuelo("Ciudad de Panamá", "Madrid", 500);

        Console.WriteLine("Base de datos cargada exitosamente!");
        Console.WriteLine($"   - {grafo.ObtenerCiudades().Count} ciudades registradas\n");
        System.Threading.Thread.Sleep(1000);

        return grafo;
    }

    private void MostrarMenuPrincipal()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("               MENÚ PRINCIPAL                           ");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\n1. Visualizar todas las rutas disponibles");
            Console.WriteLine("2. Buscar ruta más barata entre dos ciudades");
            Console.WriteLine("3. Consultar vuelos directos desde una ciudad");
            Console.WriteLine("4. Ver estadísticas del sistema");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    _sistemaVuelos.VisualizarRutas();
                    Pausar();
                    break;
                case "2":
                    BuscarRuta();
                    Pausar();
                    break;
                case "3":
                    ConsultarVuelos();
                    Pausar();
                    break;
                case "4":
                    _sistemaVuelos.MostrarEstadisticas();
                    Pausar();
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("\n¡Gracias por usar el sistema! ¡Buen viaje! ✈️\n");
                    break;
                default:
                    Console.WriteLine("\nOpción inválida. Intente nuevamente.\n");
                    Pausar();
                    break;
            }
        }
    }

    private void BuscarRuta()
    {
        Console.WriteLine("\n------------------------------------------------------");
        Console.WriteLine("          BÚSQUEDA DE RUTA MÁS BARATA                   ");
        Console.WriteLine("--------------------------------------------------------\n");

        var ciudades = _sistemaVuelos.ObtenerCiudades();
        Console.WriteLine("Ciudades disponibles:");
        for (int i = 0; i < ciudades.Count; i++)
            Console.WriteLine($"{i + 1}. {ciudades[i]}");

        Console.Write("\nIngrese ciudad de origen: ");
        string origen = Console.ReadLine();

        Console.Write("Ingrese ciudad de destino: ");
        string destino = Console.ReadLine();

        var inicio = DateTime.Now;
        _sistemaVuelos.BuscarRutaMasBarata(origen, destino);
        var fin = DateTime.Now;

        Console.WriteLine($"Tiempo de ejecución: {(fin - inicio).TotalMilliseconds:F2} ms\n");
    }

    private void ConsultarVuelos()
    {
        var ciudades = _sistemaVuelos.ObtenerCiudades();
        Console.WriteLine("\nCiudades disponibles:");
        for (int i = 0; i < ciudades.Count; i++)
            Console.WriteLine($"{i + 1}. {ciudades[i]}");

        Console.Write("\nIngrese ciudad de origen: ");
        string origen = Console.ReadLine();

        _sistemaVuelos.ConsultarVuelosDirectos(origen);
    }

    private void Pausar()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}
