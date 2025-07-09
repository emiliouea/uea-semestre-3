 
class TorresDeHanoi
{
    // Diccionario para las tres torres
    static Dictionary<string, Stack<int>> torres = new Dictionary<string, Stack<int>>()
    {
        {"A", new Stack<int>()},
        {"B", new Stack<int>()},
        {"C", new Stack<int>()}
    };

    public TorresDeHanoi()
    {
        Console.Write("Ingrese el número de discos: ");
        int numDiscos = int.Parse(Console.ReadLine());

        // Colocar discos en la torre A (inicio)
        for (int i = numDiscos; i >= 1; i--)
        {
            torres["A"].Push(i);
        }

        MostrarTorres();
        MoverDiscos(numDiscos, "A", "C", "B");
    }

    // Método recursivo para mover discos
    static void MoverDiscos(int n, string origen, string destino, string auxiliar)
    {
        if (n == 1)
        {
            MoverDisco(origen, destino);
        }
        else
        {
            MoverDiscos(n - 1, origen, auxiliar, destino);
            MoverDisco(origen, destino);
            MoverDiscos(n - 1, auxiliar, destino, origen);
        }
    }

    // Realiza el movimiento de un disco de una torre a otra
    static void MoverDisco(string desde, string hacia)
    {
        int disco = torres[desde].Pop();
        torres[hacia].Push(disco);
        Console.WriteLine($"Mover disco {disco} de {desde} a {hacia}");
        MostrarTorres();
    }

    // Muestra el estado de las torres
    static void MostrarTorres()
    {
        Console.WriteLine("\nEstado de las torres:");
        foreach (var torre in torres)
        {
            Console.Write($"{torre.Key}: ");
            foreach (var disco in torre.Value)
            {
                Console.Write(disco + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");
    }
}
