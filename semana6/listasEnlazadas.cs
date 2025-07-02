

namespace semana6;

public class Nodo
{
    public int Dato { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

// Clase que implementa la lista enlazada
public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Método para agregar un elemento al final de la lista
    public void AgregarAlFinal(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);

        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            return;
        }

        Nodo actual = cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }
        actual.Siguiente = nuevoNodo;
    }

    // Método para agregar un elemento al inicio de la lista
    public void AgregarAlInicio(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
    }

    // EJERCICIO 2: Método para invertir la lista enlazada
    public void InvertirLista()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;  // Guardamos el siguiente nodo
            actual.Siguiente = anterior;   // Invertimos el enlace
            anterior = actual;             // Movemos anterior hacia adelante
            actual = siguiente;            // Movemos actual hacia adelante
        }

        cabeza = anterior; // El nuevo cabeza es el último nodo procesado
    }

    // Método para mostrar todos los elementos de la lista
    public void MostrarLista()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    // Método para contar el número de elementos en la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    // Método para verificar si la lista está vacía
    public bool EstaVacia()
    {
        return cabeza == null;
    }
}

// Clase auxiliar para operaciones matemáticas
public static class OperacionesMatematicas
{
    // Método para verificar si un número es primo
    public static bool EsPrimo(int numero)
    {
        if (numero <= 1) return false;
        if (numero <= 3) return true;
        if (numero % 2 == 0 || numero % 3 == 0) return false;

        for (int i = 5; i * i <= numero; i += 6)
        {
            if (numero % i == 0 || numero % (i + 2) == 0)
                return false;
        }
        return true;
    }

    // Método para verificar si un número es Armstrong
    public static bool EsArmstrong(int numero)
    {
        int numeroOriginal = numero;
        int suma = 0;
        int digitos = ContarDigitos(numero);

        while (numero > 0)
        {
            int digito = numero % 10;
            suma += (int)Math.Pow(digito, digitos);
            numero /= 10;
        }

        return suma == numeroOriginal;
    }

    // Método auxiliar para contar dígitos de un número
    private static int ContarDigitos(int numero)
    {
        if (numero == 0) return 1;
        int contador = 0;
        while (numero > 0)
        {
            contador++;
            numero /= 10;
        }
        return contador;
    }
}