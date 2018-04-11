using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Note Test Repo

namespace CCS.Repositories
{
    public class TestNoteRepo : INoteRepository
    {
        private List<Note> notes;

        public List<Note> GetNotesByProject(int id) => notes.Where(a => a.ProjID == id).ToList();
        public int RemoveNote(Note n)
        {
            notes.Remove(n);
            return 1;
        }
        public Note UpdateNote(Note n)
        {
            Note oldN = notes.FirstOrDefault(a => a.ID == n.ID);
            notes.Remove(oldN);
            oldN.Text = n.Text;
            notes.Add(oldN);
            return oldN;
        }
        public Note AddNote(int id, Note n)
        {
            n.ProjID = id;
            notes.Add(n);
            return n;
        }

    }
}
