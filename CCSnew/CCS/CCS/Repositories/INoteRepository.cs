using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Repositories
{
    // CREATIVE CYBER SOLUTIONS
    // 04/11/2018
    // JOHN BELL contact@conquest-marketing.com
    //  Repo Interface for Project Notes

   public interface INoteRepository
    {
        Note AddNote(int id, Note n);
        List<Note> GetNotesByProject(int id);
        Note UpdateNote(Note n);
        int RemoveNote(Note n);
        Note GetNote(int id);
    }
}
