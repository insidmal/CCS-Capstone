using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Note Test Repo
//TO DO: Get note by ID

namespace CCS.Repositories
{
    public class TestNoteRepo : INoteRepository
    {
        private List<Note> notes = new List<Note>();

        public List<Note> GetNotesByProject(int id, bool visible) => notes.Where(a => a.ProjectID == id && a.Visible==visible).ToList<Note>();
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
            n.ProjectID = id;
            notes.Add(n);
            return n;
        }

        public Note GetNote(int id)
        {
            throw new NotImplementedException();
        }


    }
}
