
namespace parque_atraccion_sistema;

public class Asiento
{
    public int Numero { get; set; }
    public bool Ocupado { get; set; }
    public Persona Ocupante { get; set; }

    public Asiento(int numero)
    {
        Numero = numero;
        Ocupado = false;
        Ocupante = null;
    }

    public void AsignarPersona(Persona persona)
    {
        Ocupado = true;
        Ocupante = persona;
    }

    public void Liberar()
    {
        Ocupado = false;
        Ocupante = null;
    }
}
