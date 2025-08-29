using System;
using System.Collections.Generic;
using System.Linq;

namespace TraductorBasico
{
    public class Translator
    {
        private readonly Dictionary<string, string> _dictionary;

        public Translator()
        {
            // Diccionario inicial (bidireccional)
            _dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            AddWord("time", "tiempo");
            AddWord("person", "persona");
            AddWord("year", "año");
            AddWord("way", "camino");
            AddWord("day", "día");
            AddWord("thing", "cosa");
            AddWord("man", "hombre");
            AddWord("world", "mundo");
            AddWord("life", "vida");
            AddWord("hand", "mano");
            AddWord("part", "parte");
            AddWord("child", "niño");
            AddWord("eye", "ojo");
            AddWord("woman", "mujer");
            AddWord("place", "lugar");
            AddWord("work", "trabajo");
            AddWord("week", "semana");
            AddWord("case", "caso");
            AddWord("point", "punto");
            AddWord("government", "gobierno");
            AddWord("company", "empresa");
        }

        public string TranslateSentence(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return string.Empty;

            var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var translatedWords = new List<string>();

            foreach (var word in words)
            {
                string cleaned = new string(word.Where(char.IsLetter).ToArray());

                if (_dictionary.ContainsKey(cleaned))
                {
                    string translated = _dictionary[cleaned];
                    string replaced = word.Replace(cleaned, translated);
                    translatedWords.Add(replaced);
                }
                else
                {
                    translatedWords.Add(word);
                }
            }

            return string.Join(" ", translatedWords);
        }

        public bool AddWord(string word1, string word2)
        {
            if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
                return false;

            // Evitar duplicados
            if (!_dictionary.ContainsKey(word1))
                _dictionary.Add(word1.ToLower(), word2.ToLower());
            if (!_dictionary.ContainsKey(word2))
                _dictionary.Add(word2.ToLower(), word1.ToLower());

            return true;
        }
    }
}
