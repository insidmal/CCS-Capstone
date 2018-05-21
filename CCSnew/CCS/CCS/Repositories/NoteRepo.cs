using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    // CREATIVE CYBER SOLUTIONS
    // CREATED 04/19/2018
    // CREATED BY: JOHN BELL contact@conquest-marketing.com
    // UPDATED 4/24/2018
    // UPDATED BY: JOHN BELL contact@conquest-marketing.com


    public class NoteRepo : INoteRepository
    {
        private readonly AppIdentityDbContext context;

        public NoteRepo(AppIdentityDbContext ctx) {
                        context = ctx;
        }

        public Note AddNote(int id, Note n)
        {
            Note note = new Note();
            note.ProjectID = id;
            note.From = n.From;
            note.Date = DateTime.Now;
            note.Text = n.Text;
            context.Note.Add(note);
            context.SaveChanges();
            return n;
        }

        public Note GetNote(int id) => context.Note.FirstOrDefault(a => a.ID == id);

        public List<Note> GetNotesByProject(int id)
        {
            List<Note> ln = new List<Note>();
            ln = context.Note.Where(a => a.ProjectID == id).ToList();
            foreach (Note n in ln)
            {
                if (context.Users.FirstOrDefault(a => a.Id == n.From) == null) n.FromName = "[Deleted]";
                else n.FromName = context.Users.FirstOrDefault(a => a.Id == n.From).UserName;
            }
            return ln;
        }
        public int RemoveNote(Note n)
        {
            context.Note.Remove(n);
            return context.SaveChanges();
        }

        public Note UpdateNote(Note n)
        {
            context.Note.Update(n);
            context.SaveChanges();
            return n;
        }
    }
}
