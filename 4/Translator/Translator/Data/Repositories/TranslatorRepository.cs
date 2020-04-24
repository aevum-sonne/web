using System.IO;
using System.Linq;
using Translator.Data.Interfaces;
using Translator.Data.Models;

namespace Translator.Data.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly TranslatorDictionary _dictionary = new TranslatorDictionary();

        public void WriteTranslationsToDictionary(string path)
        {
            var dictionaryFile = new StreamReader(path);
            string line;
            
            while ((line = dictionaryFile.ReadLine()) != null)
            {
                var pairOfWords = line.Split(":\t");
                _dictionary.Value.Add(pairOfWords[0], pairOfWords[1]);
            }
        }

        public string GetTranslation(string word)
        {
            // English to russian
            if (_dictionary.Value.TryGetValue(word, out var translation))
            {
                return translation;
            }
            
            // Russian to english
            else if (_dictionary.Value.ContainsValue(word))
            {
                return _dictionary.Value.FirstOrDefault(x => x.Value == word).Key;
            }

            else
            {
                return null;
            }
        }
    }
}