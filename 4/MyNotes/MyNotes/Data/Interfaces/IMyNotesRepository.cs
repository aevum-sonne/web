using System.Collections.Generic;
using MyNotes.Data.Models;

namespace MyNotes.Data.Interfaces
{
    public interface IMyNotesRepository
    {
        public void LoadNotes(string path);
        public void AddNote(Notes note);
        public void SaveAsJson();
        public List<Notes> GetNotes();
    }
}