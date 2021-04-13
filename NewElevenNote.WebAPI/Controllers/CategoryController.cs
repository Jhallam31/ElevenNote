using NewElevenNote.Models.Category;
using NewElevenNote.Models.Note;
using NewElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryService svc = new CategoryService();
        public IHttpActionResult Get()
        {
            var categories = svc.GetAllCategories();
            
            
            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            var cat = svc.GetCategoryById(id);
           
            return Ok(cat);
        }

        public IHttpActionResult Post(CategoryCreate model)
        {
            var newCat = svc.CreateCategory(model);
            if (newCat == false)
            {


                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Put(CategoryEdit model)
        {
            var newCat = svc.UpdateCategory(model);
            if (newCat == false)
            {


                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            svc.DeleteCategory(id);
            return Ok();
        }
    }
}
