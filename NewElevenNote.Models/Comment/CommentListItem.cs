using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Models.Comment
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public DateTimeOffset CommentDate { get; set; }
        public string Content { get; set; }
        public string OwnerId { get; set; }

        //Note properties
        public string NoteTitle { get; set; }
        public DateTimeOffset NoteDate { get; set; }

    }
}
