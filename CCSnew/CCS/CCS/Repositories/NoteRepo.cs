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
    // UPDATED 4/23/2018
    // UPDATED BY: JOHN BELL contact@conquest-marketing.com


    public class NoteRepo : INoteRepository
    {
        private readonly AppIdentityDbContext context;

        public NoteRepo(AppIdentityDbContext ctx) {
                        context = ctx;
        }

        public Note AddNote(int id, Note n)
        {
            n.ProjectID = id;
            context.Note.Add(n);
            context.SaveChanges();
            return n;
        }

        public List<Note> GetNotesByProject(int id) => context.Note.Where(a => a.ProjectID == id).ToList();

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
