 

namespace CatalogoRevistas;


/// <summary>
/// Clase que gestiona el catálogo de revistas.
/// </summary>
public class GestorCatalogo
{
    private List<Revista> revistas;

    public GestorCatalogo()
    {
        revistas = new List<Revista>();

        // Ingreso de al menos 10 títulos
        revistas.Add(new Revista("National Geographic"));
        revistas.Add(new Revista("Time"));
        revistas.Add(new Revista("Scientific American"));
        revistas.Add(new Revista("Nature"));
        revistas.Add(new Revista("Forbes"));
        revistas.Add(new Revista("The Economist"));
        revistas.Add(new Revista("Popular Science"));
        revistas.Add(new Revista("Reader's Digest"));
        revistas.Add(new Revista("Vogue"));
        revistas.Add(new Revista("Vanity Fair"));
    }

    /// <summary>
    /// Búsqueda recursiva de un título en la lista.
    /// </summary>
    public bool BuscarTitulo(string titulo)
    {
        return BuscarRecursivo(titulo, 0);
    }

    /// <summary>
    /// Método privado que hace la búsqueda recursiva.
    /// </summary>
    private bool BuscarRecursivo(string titulo, int index)
    {
        if (index >= revistas.Count)
            return false; // Caso base: llegamos al final sin encontrarlo.

        if (revistas[index].Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true; // Caso base: encontrado.

        // Paso recursivo: buscar en el siguiente índice
        return BuscarRecursivo(titulo, index + 1);
    }

    /// <summary>
    /// Muestra todos los títulos del catálogo.
    /// </summary>
    public void MostrarCatalogo()
    {
        Console.WriteLine("\n--- Catálogo de Revistas ---");
        foreach (var revista in revistas)
        {
            Console.WriteLine("- " + revista.Titulo);
        }
        Console.WriteLine("----------------------------\n");
    }
}
