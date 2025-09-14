 

namespace CatalogoRevistas;

/// <summary>
/// Clase que representa una revista con su título.
/// </summary>
public class Revista
{
    public string Titulo { get; set; }

    public Revista(string titulo)
    {
        Titulo = titulo;
    }
}