using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Models.Comment
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string OwnerId { get; set; }
        public DateTimeOffset CommentDate { get; set; }

        //Note properties
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public DateTimeOffset NoteDate { get; set; }
    }
}
