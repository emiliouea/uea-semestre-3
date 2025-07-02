using semana6;

Console.WriteLine("=== EJERCICIOS DE LISTAS ENLAZADAS ===\n");

// EJERCICIO 2: Demostración de inversión de lista
Console.WriteLine("EJERCICIO 2: INVERTIR UNA LISTA ENLAZADA");
Console.WriteLine("========================================");

ListaEnlazada listaOriginal = new ListaEnlazada();

// Agregamos algunos elementos a la lista
Console.WriteLine("Creando lista original con elementos: 1, 2, 3, 4, 5");
for (int i = 1; i <= 5; i++)
{
    listaOriginal.AgregarAlFinal(i);
}

Console.Write("Lista original: ");
listaOriginal.MostrarLista();

// Invertimos la lista
listaOriginal.InvertirLista();

Console.Write("Lista invertida: ");
listaOriginal.MostrarLista();

Console.WriteLine("\n" + new string('=', 50) + "\n");

// EJERCICIO 5: Listas de números primos y Armstrong
Console.WriteLine("EJERCICIO 5: LISTAS DE NÚMEROS PRIMOS Y ARMSTRONG");
Console.WriteLine("=================================================");

ListaEnlazada listaPrimos = new ListaEnlazada();
ListaEnlazada listaArmstrong = new ListaEnlazada();

// Generar números del 1 al 100 y clasificarlos
Console.WriteLine("Analizando números del 1 al 200...\n");

for (int i = 1; i <= 200; i++)
{
    if (OperacionesMatematicas.EsPrimo(i))
    {
        listaPrimos.AgregarAlFinal(i); // Se agregan al final
    }

    if (OperacionesMatematicas.EsArmstrong(i))
    {
        listaArmstrong.AgregarAlInicio(i); // Se agregan al inicio
    }
}

// a. Mostrar el número de datos insertados en cada lista
Console.WriteLine("a) NÚMERO DE ELEMENTOS EN CADA LISTA:");
Console.WriteLine($"   - Lista de números primos: {listaPrimos.ContarElementos()} elementos");
Console.WriteLine($"   - Lista de números Armstrong: {listaArmstrong.ContarElementos()} elementos");

// b. Mostrar qué lista contiene más elementos
Console.WriteLine("\nb) LISTA CON MÁS ELEMENTOS:");
int cantidadPrimos = listaPrimos.ContarElementos();
int cantidadArmstrong = listaArmstrong.ContarElementos();

if (cantidadPrimos > cantidadArmstrong)
{
    Console.WriteLine("   La lista de números primos contiene más elementos.");
}
else if (cantidadArmstrong > cantidadPrimos)
{
    Console.WriteLine("   La lista de números Armstrong contiene más elementos.");
}
else
{
    Console.WriteLine("   Ambas listas tienen la misma cantidad de elementos.");
}

// c. Mostrar todos los datos insertados en las listas
Console.WriteLine("\nc) DATOS INSERTADOS EN LAS LISTAS:");

Console.WriteLine("\n   NÚMEROS PRIMOS (agregados al final):");
Console.Write("   ");
listaPrimos.MostrarLista();

Console.WriteLine("\n   NÚMEROS ARMSTRONG (agregados al inicio):");
Console.Write("   ");
listaArmstrong.MostrarLista();

Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
Console.WriteLine("Presione cualquier tecla para salir...");
Console.ReadKey();