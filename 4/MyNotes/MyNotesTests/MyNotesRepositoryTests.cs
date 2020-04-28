using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using MyNotes.Data.Repositories;

namespace MyNotesTests
{
    public class Tests
    {
        private IMyNotesRepository _notes;

        private static bool CompareListsOfNotes(List<Notes> expected, List<Notes> result)
        {
            if (expected.Count != result.Count) return false;
            for (var i = 0; i < result.Count; i++)
            {
                if (expected[i].Note != result[i].Note)
                {
                    return false;
                }
            }

            return true;
        }
        
        [SetUp]
        public void Setup()
        {
            _notes = new MyNotesRepository();
            _notes.LoadNotes("/Users/user/dev/web/4/MyNotes/MyNotes/Data/Resources/Notes.json");
        }

        [Test]
        public void PrintAllNotesFormJson()
        {
            var expectedJson = new List<Notes>
            {
                new Notes {Note = "456"},
                new Notes {Note = "123"},
                new Notes {Note = "789"},
                new Notes {Note = "9999"}
            };
            
            var resultJson = _notes.GetNotes();
            
            Assert.IsTrue(CompareListsOfNotes(expectedJson, resultJson));
        }
        
        [TestCase("новая заметка 1234567")]
        [TestCase("lksdjsldkfkjsdlkfjsfd")]
        [TestCase("123213123123123123")]

        public void AddCorrectNote(string note)
        {
            var newNote = new Notes {Note = note};
            var expectedJson = new List<Notes>
            {
                new Notes {Note = "456"},
                new Notes {Note = "123"},
                new Notes {Note = "789"},
                new Notes {Note = "9999"},
                new Notes {Note = note}
            };
            
            _notes.AddNote(newNote);
            var resultJson = _notes.GetNotes();

            Assert.IsTrue(CompareListsOfNotes(expectedJson, resultJson));
        }
        
        [TestCase("")]
        [TestCase(null)]

        public void AddNotCorrectNote(string note)
        {
            var newNote = new Notes {Note = note};
            var expectedJson = new List<Notes>
            {
                new Notes {Note = "456"},
                new Notes {Note = "123"},
                new Notes {Note = "789"},
                new Notes {Note = "9999"}
            };
            
            _notes.AddNote(newNote);
            var resultJson = _notes.GetNotes();

            Assert.IsTrue(CompareListsOfNotes(expectedJson, resultJson));
        }
    }
}