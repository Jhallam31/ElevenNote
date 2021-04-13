using NewElevenNote.Models.Note;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Models.Category
{
    public class CategoryListItem
    {
        [Display(Name="ID")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int NoteCount { get; set; }
    }
}
