using NewElevenNote.Data.Entity_Models;
using NewElevenNote.Data;
using NewElevenNote.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewElevenNote.Models.Note;

namespace NewElevenNote.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Name = model.Name
                };

            using (ctx)
            {

                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (ctx)
            {

                var query =
                ctx
                .Categories
                .Where(c => c.CategoryId == c.CategoryId)
                .Select(c => new CategoryListItem
                {

                    CategoryId = c.CategoryId,
                    Name = c.Name
                    


                });

                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (ctx)
            {

                var entity =
                ctx
                .Categories
                .Single(c => c.CategoryId == id);

                var name = entity.Name;
                return new CategoryDetail
                {
                    CategoryId = entity.CategoryId,
                    Name = entity.Name,
                    NotesInCategory = GetNotesInCategory(id,name)
                };
            }
        }

        public List<NoteListItem> GetNotesInCategory(int id, string catName)
        {
            using (ctx)
            {

                var notes =
                ctx
                .Notes
                .Where(n => n.CategoryId == id)
                .Select(n => new NoteListItem()
                {
                    NoteId = n.NoteId,
                    Title = n.Title,
                    CategoryName = catName,
                    CreatedUtc = n.CreatedUtc
                });
                return notes.ToList();
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (ctx)
            {

                var entity =
                ctx
                .Categories
                .Single(c => c.CategoryId == model.CategoryId);


                entity.Name = model.Name;
                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteCategory(int id)
        {
            using (ctx)
            {

                var entity =
                ctx
                .Categories
                .Single(c => c.CategoryId == id);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
