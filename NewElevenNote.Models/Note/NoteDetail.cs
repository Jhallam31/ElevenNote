using NewElevenNote.Models.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Models.Note
{
    public class NoteDetail
    {
        [Display(Name ="ID")]
        public int NoteId { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string CategoryName { get; set; }
        public List<CommentListItem> Comments { get; set; }
    }
}
