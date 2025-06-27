using EjercioPOO;
//using System;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//List<string> nombres = [
//    "Felipe",
//    "Alice",
//    "Bob",
//    "Charlie"
//];
//nombres.Add("Diana");
//nombres.Add("Eve");

//nombres.Remove("Charlie");
//nombres.Sort();
//foreach (string item in nombres)
//{
//    Console.WriteLine($"Hola {item.ToUpper()}");
//}

//Console.WriteLine($"Mi nombre es: {nombres[3]}");
//Console.WriteLine($"Total nombres: {nombres.Count}");


////Busqueda de un nombre mediante un indexOf
//var index = nombres.IndexOf("Felipe");
//if (index == -1)
//{
//    Console.WriteLine($"Cuando un item no se encuenta, IndexOf retorna { index}");
// }
//else
//{
//    Console.WriteLine($"El nombre { nombres[index]} esta en el índice { index}");
// }


//Fibonacci
//List<int> fibonacciNumberos = [1,1];
//int anterior = fibonacciNumberos[fibonacciNumberos.Count - 1];
//int anterior1 = fibonacciNumberos[fibonacciNumberos.Count - 2];
//fibonacciNumberos.Add(anterior + anterior1);
//Console.WriteLine(fibonacciNumberos.Count - 1);
//Console.WriteLine(fibonacciNumberos.Count - 2);
//Console.WriteLine($"Fibonacci: {anterior}, {anterior1}");


//while(fibonacciNumberos.Count < 100)
//{
//    int previous = fibonacciNumberos[fibonacciNumberos.Count - 1];
//    int previous2  = fibonacciNumberos[fibonacciNumberos.Count - 2];
//    fibonacciNumberos.Add(previous + previous2); 
//}
//foreach (int item in fibonacciNumberos)
//{
//    Console.WriteLine(item);
//}

//Tarea ejericiosPOO.cs

using EjercioPOO;

Console.WriteLine("=== EJERCICIOS DE PROGRAMACIÓN ORIENTADA A OBJETOS ===\n");

// Ejercicio 1: Estadísticas de números
Console.WriteLine("EJERCICIO 1: Estadísticas de números");
Console.WriteLine("Ingrese números separados por comas:");
string entrada = Console.ReadLine();

EstadisticasNumeros stats = new EstadisticasNumeros();
stats.CargarNumeros(entrada);
stats.MostrarEstadisticas();
Console.WriteLine();

// Ejercicio 2: Análisis de precios
Console.WriteLine("EJERCICIO 2: Análisis de precios");
AnalisisPrecios analisis = new AnalisisPrecios();
analisis.MostrarResultados();
Console.WriteLine();

// Ejercicio 3: Contador de vocales
Console.WriteLine("EJERCICIO 3: Contador de vocales");
Console.WriteLine("Ingrese una palabra:");
string palabra = Console.ReadLine();

ContadorVocales contador = new ContadorVocales();
contador.ContarVocales(palabra);
contador.MostrarResultados();
Console.WriteLine();

// Ejercicio 4: Manipulador de abecedario
Console.WriteLine("EJERCICIO 4: Abecedario sin múltiplos de 3");
ManipuladorAbecedario manipulador = new ManipuladorAbecedario();
manipulador.EliminarMultiplosDe3();
manipulador.MostrarAbecedario();
Console.WriteLine();

// Ejercicio 5: Verificador de palíndromos
Console.WriteLine("EJERCICIO 5: Verificador de palíndromos");
Console.WriteLine("Ingrese una palabra:");
string palabraPalindromo = Console.ReadLine();

VerificadorPalindromo verificador = new VerificadorPalindromo();
verificador.VerificarPalindromo(palabraPalindromo);

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();