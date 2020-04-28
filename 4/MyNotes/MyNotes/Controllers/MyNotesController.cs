using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;

namespace MyNotes.Controllers
{
    public class MyNotesController : Controller
    {
        private readonly IMyNotesRepository _myNotesRepository;

        public MyNotesController(IMyNotesRepository myNotesRepository)
        {
            _myNotesRepository = myNotesRepository;
            _myNotesRepository.LoadNotes("Data/Resources/Notes.json");
        }
        
        [HttpPost]
        [Route("note/add")]
        [Produces("text/html; charset=utf-8")]
        public IActionResult AddNote([FromBody] string note)
        {
            if (!string.IsNullOrEmpty(note))
            {
                var newNote = new Notes {Note = note};
                
                _myNotesRepository.AddNote(newNote);
                _myNotesRepository.SaveAsJson();
                
                ViewBag.response = "Note \"" + note + "\" added.";
            }
            else
            {
                ViewBag.response = "Note isn't added.";
            }

            return View("AddResult");
        }
        
        [HttpGet]
        [Route("notes/list")]
        [Produces("application/json; charset=utf-8")]
        public ActionResult PrintNotes()
        {
            var json = _myNotesRepository.GetNotes();

            return Json(json);
        }
    }
}