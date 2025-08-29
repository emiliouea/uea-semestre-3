 

namespace TraductorBasico
{
    public class TranslatorApp
    {
        private readonly Translator _translator;

        public TranslatorApp()
        {
            _translator = new Translator();
        }

        public void Run()
        {
            int option;
            do
            {
                ShowMenu();
                option = ReadOption();

                switch (option)
                {
                    case 1:
                        TranslateSentence();
                        break;
                    case 2:
                        AddWordToDictionary();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

            } while (option != 0);
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private int ReadOption()
        {
            if (int.TryParse(Console.ReadLine(), out int option))
                return option;

            return -1;
        }

        private void TranslateSentence()
        {
            Console.Write("\nIngrese la frase: ");
            string sentence = Console.ReadLine();
            string translated = _translator.TranslateSentence(sentence);
            Console.WriteLine("\nTraducción parcial:");
            Console.WriteLine(translated);
        }

        private void AddWordToDictionary()
        {
            Console.Write("\nIngrese la primera palabra: ");
            string word1 = Console.ReadLine()?.Trim();

            Console.Write("Ingrese su traducción: ");
            string word2 = Console.ReadLine()?.Trim();

            bool added = _translator.AddWord(word1, word2);
            if (added)
                Console.WriteLine($"Palabras agregadas correctamente: {word1} <-> {word2}");
            else
                Console.WriteLine("No se pudo agregar la palabra (entrada inválida o ya existente).");
        }
    }
}
