using NewElevenNote.Data;
using NewElevenNote.Data.Entity_Models;
using NewElevenNote.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        private readonly string _userId;

        public CommentService(string userId)
        {
            _userId = userId;
        }
        public bool CommentCreate(CommentCreate model)
        {
            var entity =
                new Comment()
                {

                    Content = model.Content,
                    OwnerId = _userId,
                    CommentDate = DateTimeOffset.Now,
                    NoteId = model.NoteId

                };
            using (ctx) 
            { 
                ctx.Comments.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<CommentListItem> GetAllComments()
        {
            using (ctx)
            {
                var query =
                ctx
                .Comments
                .Where(e => e.OwnerId == _userId)
                .Select(e => new CommentListItem
                {
                    CommentId = e.CommentId,
                    CommentDate = e.CommentDate,
                    Content = e.Content,
                    OwnerId = e.OwnerId,
                    NoteTitle = e.Note.Title,
                    NoteDate = e.Note.CreatedUtc
                });

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Comments
                .Single(n => n.CommentId == id && n.OwnerId == _userId);


                return new CommentDetail
                {
                    CommentId = entity.CommentId,
                    Content = entity.Content,
                    OwnerId = entity.OwnerId,
                    CommentDate = entity.CommentDate,
                    NoteTitle = entity.Note.Title,
                    NoteContent = entity.Note.Content,
                    NoteDate = entity.Note.CreatedUtc


                };

            }

        }
        public bool UpdateComment(CommentEdit model)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Comments
                .Single(n => n.CommentId == model.CommentId && n.OwnerId == _userId);

                entity.Content = model.Content;

                    return ctx.SaveChanges() == 1;
                
            }

        }
        public bool DeleteComment(int id)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Comments
                .Single(n => n.CommentId == id && n.OwnerId == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

