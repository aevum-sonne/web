using Microsoft.AspNetCore.Mvc;
using Translator.Data.Models;

namespace Translator.Data.Interfaces
{
    public interface ITranslatorRepository
    {
        public void WriteTranslationsToDictionary(string path);
        public string GetTranslation(string word);
    }
}