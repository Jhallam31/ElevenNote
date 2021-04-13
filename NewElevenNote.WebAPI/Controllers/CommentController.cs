using Microsoft.AspNet.Identity;
using NewElevenNote.Models.Comment;
using NewElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewElevenNote.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            var svc = CreateCommentService();
            var comments = svc.GetAllComments();


            return Ok(comments);
        }

        public IHttpActionResult Get(int id)
        {
            var svc = CreateCommentService();
            var cat = svc.GetCommentById(id);

            return Ok(cat);
        }

        public IHttpActionResult Post(CommentCreate model)
        {
            var svc = CreateCommentService();
            var newCat = svc.CommentCreate(model);
            if (newCat == false)
            {


                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Put(CommentEdit model)
        {
            var svc = CreateCommentService();
            var newCat = svc.UpdateComment(model);
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
            var svc = CreateCommentService();
            svc.DeleteComment(id);
            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var userId = User.Identity.GetUserId();
            return new CommentService(userId);
        }
    }
}
