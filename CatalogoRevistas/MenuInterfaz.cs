 

namespace CatalogoRevistas;

/// <summary>
/// Clase para gestionar la interacción con el usuario.
/// </summary>
public class MenuInterfaz
{
    private GestorCatalogo gestor;

    public MenuInterfaz(GestorCatalogo gestorCatalogo)
    {
        gestor = gestorCatalogo;
    }

    /// <summary>
    /// Muestra el menú y procesa la elección del usuario.
    /// </summary>
    public void MostrarMenu()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("=== MENÚ CATÁLOGO DE REVISTAS ===");
            Console.WriteLine("1. Mostrar Catálogo");
            Console.WriteLine("2. Buscar Revista");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            // Validación simple
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida.\n");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    gestor.MostrarCatalogo();
                    break;

                case 2:
                    Console.Write("\nIngrese el título de la revista a buscar: ");
                    string titulo = Console.ReadLine();
                    bool encontrado = gestor.BuscarTitulo(titulo);

                    if (encontrado)
                        Console.WriteLine("\n✅ Revista encontrada.\n");
                    else
                        Console.WriteLine("\n❌ Revista no encontrada.\n");
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.\n");
                    break;
            }

        } while (opcion != 3);
    }
}