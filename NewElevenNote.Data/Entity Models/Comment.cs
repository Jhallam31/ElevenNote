using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Data.Entity_Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Content { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public DateTimeOffset CommentDate { get; set; }

        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }



    }
}
