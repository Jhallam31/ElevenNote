using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewElevenNote.Data.Entity_Models;
using NewElevenNote.Models.Note;

namespace NewElevenNote.Models.Category
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Display(Name="Notes")]
        public List<NoteListItem> NotesInCategory { get; set; }
        
    }
}
