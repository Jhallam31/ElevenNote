using Microsoft.AspNet.Identity;
using NewElevenNote.Models.Note;
using NewElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NewElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        
        // GET: Note
        public IHttpActionResult Get()
        {
            NoteService svc = CreateNoteService();
            var notes = svc.GetAllNotes();
            return Ok(notes);
        }
        public IHttpActionResult Get(int id)
        {
            NoteService svc = CreateNoteService();
            var note = svc.GetNoteById(id);
            return Ok(note);
        }
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.NoteCreate(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            NoteService svc = CreateNoteService();
            svc.DeleteNote(id);
            return Ok();
        }
        private NoteService CreateNoteService()
        {
            var userId = User.Identity.GetUserId();
            var noteService = new NoteService(userId);
            return noteService;
        }
    }
}