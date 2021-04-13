using NewElevenNote.Data;
using NewElevenNote.Data.Entity_Models;
using NewElevenNote.Models.Comment;
using NewElevenNote.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewElevenNote.Services
{
    public class NoteService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly string _userId;
        
        public NoteService(string userId)
        {
            _userId = userId;
        }
        public bool NoteCreate(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    Title = model.Title,
                    Content = model.Content,
                    OwnerId = _userId,
                    CategoryId = model.CategoryId,
                    CreatedUtc = DateTime.Now
                };
            using(ctx)
            {

            ctx.Notes.Add(entity);

            //add note to category's list of Notes
            
            return ctx.SaveChanges() == 1;
            }
        }
       

        public IEnumerable<NoteListItem> GetAllNotes()
        {
            using (ctx)
            {
                var query =
                ctx
                .Notes
                .Where(e => e.OwnerId == _userId)
                .Select(e => new NoteListItem
                {
                    NoteId = e.NoteId,
                    Title = e.Title,
                    CategoryName = e.Category.Name,
                    CreatedUtc = e.CreatedUtc
                });

                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Notes
                .Single(n => n.NoteId == id && n.OwnerId == _userId);

                var noteTitle = entity.Title;
                var noteDate = entity.CreatedUtc;
                if (entity.ModifiedUtc != null)
                {
                    return new NoteDetail
                    {
                        Title = entity.Title,
                        Content = entity.Content,
                        NoteId = entity.NoteId,
                        CreatedUtc = entity.CreatedUtc,
                        CategoryName = entity.Category.Name,
                        Comments = GetCommentsInCategory(id,noteTitle,noteDate),
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                else
                {

                    return new NoteDetail
                    {
                        Title = entity.Title,
                        Content = entity.Content,
                        NoteId = entity.NoteId,
                        CategoryName = entity.Category.Name,
                        CreatedUtc = entity.CreatedUtc,
                        Comments = GetCommentsInCategory(id, noteTitle, noteDate)

                    };
                }
            }

        }
        public List<CommentListItem> GetCommentsInCategory(int id, string title,DateTimeOffset noteDate)
        {
            using (ctx)
            {

                var comments =
                ctx
                .Comments
                .Where(n => n.NoteId == id && n.OwnerId == _userId)
                .Select(n => new CommentListItem()
                {
                    CommentId = n.CommentId,
                    OwnerId = n.OwnerId,
                    NoteDate = noteDate,
                    NoteTitle = title,
                    Content =n.Content,
                    CommentDate = n.CommentDate
                });
                return comments.ToList();
            }
        }
        public bool UpdateNote(NoteEdit model)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Notes
                .Single(n => n.NoteId == model.NoteId && n.OwnerId == _userId);
                if (model.CategoryId != entity.CategoryId)
                {

                    entity.Title = model.Title;
                    entity.Content = model.Content;
                    entity.CategoryId = model.CategoryId;
                    entity.ModifiedUtc = DateTime.Now;

                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    entity.Title = model.Title;
                    entity.Content = model.Content;

                    entity.ModifiedUtc = DateTime.Now;

                    return ctx.SaveChanges() == 1;
                }
            }

        }
        public bool DeleteNote(int id)
        {
            using (ctx)
            {
                var entity =
                ctx
                .Notes
                .Single(n => n.NoteId == id && n.OwnerId == _userId);
                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
