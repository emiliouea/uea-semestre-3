using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana7;

public class GameStack
{
    Stack<int> myStack = new Stack<int>();
    public GameStack()
    {
        Console.WriteLine("Game Stack Initialized");
        // Constructor logic can be added here if needed
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Game Stack Menu ===");
            choice = MostrarMenu(); 
            switch (choice)
            {
                case 1:
                   Add();
                    break;
                case 2:
                    Remove();
                    break;
                case 3:
                   Clear();
                    break;
                case 4:
                    Print();
                break;
                case 5: break;
                default:
                    Message("Opción inválida, por favor intente de nuevo.");
                    break;

            }
        }
        while (choice!=5);
        Console.WriteLine("Saliendo del programa...");
    }

    int MostrarMenu()
    {
        Console.WriteLine("1. Agregar elemento al stack");
        Console.WriteLine("2. Eliminar elemento del stack");
        Console.WriteLine("3. Vaciar stack");
        Console.WriteLine("4. Ver stack");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: "); 

        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }catch
        {
            return -1;
        }
    }

    void Add()
    {
        Console.Write("Ingrese un número para agregar al stack: ");
        try
        {
            int numberToAdd = int.Parse(Console.ReadLine());
            if (numberToAdd > 99 && numberToAdd <= 0) {
                Message("Número fuera de rango. Debe ser un número positivo menor o igual a 99.");
                return;

            }
            myStack.Push(numberToAdd);
            Print();
        } catch (FormatException)
        {
            Message("Entrada inválida. Por favor, ingrese un número válido.");

        }
     }

    void Remove()
    {
        if (myStack.Count > 0)
        {
            int removedNumber = myStack.Pop();
            Message($"Número {removedNumber} eliminado del stack.");
        }
        else
        {
            Print();
        } 
    }

    void Clear()
    {
        myStack.Clear();
        Print();
    }

    void Print()
    { 
        if (myStack.Count > 0)
        {
            Console.WriteLine(
                "Contenido del stack: " + string.Join(", ", myStack.Reverse()));
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
             Console.ReadKey();
        }
        else
        {
            Message("El stack está vacío.");

        }

    
    }

    void Message(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }   
}


