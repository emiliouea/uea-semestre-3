 

namespace parque_atraccion_sistema;
public class GestorAtraccion
{
    private Queue<Persona> colaEspera;
    private List<Asiento> asientos;
    private const int CAPACIDAD_MAXIMA = 30;

    public GestorAtraccion()
    {
        colaEspera = new Queue<Persona>();
        asientos = new List<Asiento>();

        // Inicializar los 30 asientos
        for (int i = 1; i <= CAPACIDAD_MAXIMA; i++)
        {
            asientos.Add(new Asiento(i));
        }
    }

    public bool AgregarPersonaACola(Persona persona)
    {
        if (colaEspera.Count + AsientosOcupados() >= CAPACIDAD_MAXIMA)
        {
            return false; // No hay espacio
        }

        colaEspera.Enqueue(persona);
        return true;
    }

    public bool ProcesarSiguienteEnCola()
    {
        if (colaEspera.Count == 0)
        {
            return false; // No hay personas en cola
        }

        var siguienteAsiento = asientos.FirstOrDefault(a => !a.Ocupado);
        if (siguienteAsiento == null)
        {
            return false; // No hay asientos disponibles
        }

        var persona = colaEspera.Dequeue();
        siguienteAsiento.AsignarPersona(persona);
        return true;
    }

    public void MostrarEstadoCola()
    {
        Console.WriteLine("\n=== ESTADO DE LA COLA ===");
        Console.WriteLine($"Personas en espera: {colaEspera.Count}");

        if (colaEspera.Count == 0)
        {
            Console.WriteLine("No hay personas en la cola.");
            return;
        }

        int posicion = 1;
        foreach (var persona in colaEspera)
        {
            Console.WriteLine($"{posicion}. {persona}");
            posicion++;
        }
    }

    public void MostrarAsientosOcupados()
    {
        Console.WriteLine("\n=== ASIENTOS OCUPADOS ===");
        var asientosOcupados = asientos.Where(a => a.Ocupado).ToList();

        if (asientosOcupados.Count == 0)
        {
            Console.WriteLine("No hay asientos ocupados.");
            return;
        }

        foreach (var asiento in asientosOcupados)
        {
            Console.WriteLine($"Asiento {asiento.Numero}: {asiento.Ocupante}");
        }
    }

    public void MostrarResumen()
    {
        Console.WriteLine("\n=== RESUMEN GENERAL ===");
        Console.WriteLine($"Asientos ocupados: {AsientosOcupados()}/{CAPACIDAD_MAXIMA}");
        Console.WriteLine($"Personas en cola: {colaEspera.Count}");
        Console.WriteLine($"Asientos disponibles: {CAPACIDAD_MAXIMA - AsientosOcupados()}");
    }

    public bool BuscarPersona(string identificacion)
    {
        // Buscar en cola
        var enCola = colaEspera.FirstOrDefault(p => p.Identificacion == identificacion);
        if (enCola != null)
        {
            Console.WriteLine($"Persona encontrada en cola: {enCola}");
            return true;
        }

        // Buscar en asientos ocupados
        var enAsiento = asientos.FirstOrDefault(a => a.Ocupado && a.Ocupante.Identificacion == identificacion);
        if (enAsiento != null)
        {
            Console.WriteLine($"Persona encontrada en asiento {enAsiento.Numero}: {enAsiento.Ocupante}");
            return true;
        }

        Console.WriteLine("Persona no encontrada en el sistema.");
        return false;
    }

    public void ReiniciarSesion()
    {
        colaEspera.Clear();
        foreach (var asiento in asientos)
        {
            asiento.Liberar();
        }
        Console.WriteLine("Sistema reiniciado para nueva sesión.");
    }

    private int AsientosOcupados()
    {
        return asientos.Count(a => a.Ocupado);
    }

    public int PersonasEnCola()
    {
        return colaEspera.Count;
    }
}