 
class VerificacionBalanceo
{
   
    public VerificacionBalanceo()
    {
        Console.WriteLine("Ingrese la expresión matemática:");
        string expresion = Console.ReadLine();

        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula no balanceada.");
    }

    // Método que verifica si la expresión tiene símbolos balanceados
    static bool EstaBalanceada(string expr)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expr)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c); // Agrega apertura
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;

                char simboloApertura = pila.Pop();

                if (!EsPar(simboloApertura, c))
                    return false;
            }
        }

        return pila.Count == 0;
    }

    // Verifica que el símbolo de apertura y cierre coincidan
    static bool EsPar(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}
