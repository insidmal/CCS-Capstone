using CCS.Models;
using CCS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CCS.Tests
{

    public class NotesTests
    {
        INoteRepository repo;
        private List<Project> projects = new List<Project>() { new Project { ID = 1 }, new Project { ID = 2 }, new Project { ID = 3 } };

        public NotesTests()
        {
            repo = new TestNoteRepo();
        }

        [Fact]
        public void NoteAddTest()
        {
            Assert.Empty(repo.GetNotesByProject(1,true));
            repo.AddNote(1, new Note() { Text="Test Note" });
            Assert.Single(repo.GetNotesByProject(1, true));

        }

        [Fact]
        public void GetNotesByProjectTest()
        {
            Assert.Empty(repo.GetNotesByProject(1, true));
            repo.AddNote(1, new Note() { Text = "Test Note" });
            Assert.Single(repo.GetNotesByProject(1, true));

        }

        [Fact]
        public void UpdateNoteTest()
        {
            Note n = new Note() { Text = "Test Note" };
            repo.AddNote(1, n);
            Note testNote = repo.GetNotesByProject(1, true)[0];
            testNote.Text = "Updated Text";
            repo.UpdateNote(testNote);
            Assert.Equal("Updated Text", repo.GetNotesByProject(1, true)[0].Text);
        }

        [Fact]
        public void RemoveNoteTest()
        {
            Assert.Empty(repo.GetNotesByProject(1, true));
            Note n = new Note() { ProjectID=1, Text = "Test Note" };
            repo.AddNote(1, n);
            Assert.Single(repo.GetNotesByProject(1, true));
            repo.RemoveNote(n);
            Assert.Empty(repo.GetNotesByProject(1, true));

        }
    }
}
