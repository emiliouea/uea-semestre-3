 

namespace EjercioPOO;


// Ejercicio 1: Estadísticas de números
public class EstadisticasNumeros
{
    private List<double> numeros;

    public EstadisticasNumeros()
    {
        numeros = new List<double>();
    }

    public void CargarNumeros(string entrada)
    {
        string[] numerosStr = entrada.Split(',');
        foreach (string num in numerosStr)
        {
            if (double.TryParse(num.Trim(), out double numero))
            {
                numeros.Add(numero);
            }
        }
    }

    public double CalcularMedia()
    {
        return numeros.Count > 0 ? numeros.Average() : 0;
    }

    public double CalcularDesviacionTipica()
    {
        if (numeros.Count <= 1) return 0;

        double media = CalcularMedia();
        double sumaCuadrados = numeros.Sum(x => Math.Pow(x - media, 2));
        return Math.Sqrt(sumaCuadrados / (numeros.Count - 1));
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine($"Media: {CalcularMedia():F2}");
        Console.WriteLine($"Desviación Típica: {CalcularDesviacionTipica():F2}");
    }
}

// Ejercicio 2: Análisis de precios
public class AnalisisPrecios
{
    private List<int> precios;

    public AnalisisPrecios()
    {
        precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
    }

    public int ObtenerPrecioMenor()
    {
        return precios.Min();
    }

    public int ObtenerPrecioMayor()
    {
        return precios.Max();
    }

    public void MostrarResultados()
    {
        Console.WriteLine($"Precio menor: {ObtenerPrecioMenor()}");
        Console.WriteLine($"Precio mayor: {ObtenerPrecioMayor()}");
    }
}

// Ejercicio 3: Contador de vocales
public class ContadorVocales
{
    private Dictionary<char, int> conteoVocales;

    public ContadorVocales()
    {
        conteoVocales = new Dictionary<char, int>
            {
                {'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}
            };
    }

    public void ContarVocales(string palabra)
    {
        // Reiniciar contadores
        foreach (var key in conteoVocales.Keys.ToList())
        {
            conteoVocales[key] = 0;
        }

        // Contar vocales
        foreach (char letra in palabra.ToLower())
        {
            if (conteoVocales.ContainsKey(letra))
            {
                conteoVocales[letra]++;
            }
        }
    }

    public void MostrarResultados()
    {
        foreach (var vocal in conteoVocales)
        {
            Console.WriteLine($"Vocal '{vocal.Key}': {vocal.Value} veces");
        }
    }
}

// Ejercicio 4: Manipulador de abecedario
public class ManipuladorAbecedario
{
    private List<char> abecedario;

    public ManipuladorAbecedario()
    {
        abecedario = new List<char>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            abecedario.Add(c);
        }
    }

    public void EliminarMultiplosDe3()
    {
        // Crear una nueva lista sin los elementos en posiciones múltiplos de 3
        List<char> nuevaLista = new List<char>();
        for (int i = 0; i < abecedario.Count; i++)
        {
            // Las posiciones múltiplos de 3 son: 3, 6, 9, 12... (índices 2, 5, 8, 11...)
            if ((i + 1) % 3 != 0)
            {
                nuevaLista.Add(abecedario[i]);
            }
        }
        abecedario = nuevaLista;
    }

    public void MostrarAbecedario()
    {
        Console.WriteLine("Abecedario resultante:");
        Console.WriteLine(string.Join(", ", abecedario));
    }
}

// Ejercicio 5: Verificador de palíndromos
public class VerificadorPalindromo
{
    public bool EsPalindromo(string palabra)
    {
        // Convertir a minúsculas y eliminar espacios
        string palabraLimpia = palabra.ToLower().Replace(" ", "");

        // Comparar la palabra con su reverso
        string palabraReversa = new string(palabraLimpia.Reverse().ToArray());

        return palabraLimpia == palabraReversa;
    }

    public void VerificarPalindromo(string palabra)
    {
        if (EsPalindromo(palabra))
        {
            Console.WriteLine($"'{palabra}' SÍ es un palíndromo.");
        }
        else
        {
            Console.WriteLine($"'{palabra}' NO es un palíndromo.");
        }
    }
}

