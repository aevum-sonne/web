using System;
using Microsoft.AspNetCore.Mvc;
using Translator.Data.Interfaces;

namespace Translator.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ITranslatorRepository _translatorRepository;

        public TranslatorController(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;
            _translatorRepository.WriteTranslationsToDictionary("Data/Repositories/Dictionary.txt");
        }

        // GET
        public ViewResult Translate(string word)
        {
            ViewBag.translation = _translatorRepository.GetTranslation(word);
            ViewBag.word = word;
            
            return View("Translation");
        }
    }
}