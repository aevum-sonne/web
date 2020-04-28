using System;
using System.Collections.Generic;
using System.IO;
using MyNotes.Controllers;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using Newtonsoft.Json;

namespace MyNotes.Data.Repositories
{
    public class MyNotesRepository : IMyNotesRepository
    {
        private List<Notes> _notes;
        private string _path;

        public void LoadNotes(string path)
        {
            _path = path;
            using var file = new StreamReader(_path);
            
            var content = file.ReadToEnd();
            _notes = JsonConvert.DeserializeObject<List<Notes>>(content);
        }

        public void AddNote(Notes note)
        {
            // Input note is empty
            if (string.IsNullOrEmpty(note.Note)) return;
            
            _notes.Add(note);
        }

        public void SaveAsJson()
        {
            var output = JsonConvert.SerializeObject(_notes, Formatting.Indented);
            File.WriteAllText(_path, output);
        }

        public List<Notes> GetNotes()
        {
            return _notes;
        }
    }
}