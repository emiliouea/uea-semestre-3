
namespace parque_atraccion_sistema;

public class Persona
{
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
    public int Edad { get; set; }
    public DateTime HoraLlegada { get; set; }

    public Persona(string nombre, string identificacion, int edad)
    {
        Nombre = nombre;
        Identificacion = identificacion;
        Edad = edad;
        HoraLlegada = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, ID: {Identificacion}, Edad: {Edad}, Llegada: {HoraLlegada:HH:mm:ss}";
    }
}
