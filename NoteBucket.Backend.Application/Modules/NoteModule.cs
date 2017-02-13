using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Responses;
using Nancy.Security;
using Nancy.ModelBinding;
using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Application.DataTransferModels;
using NoteBucket.Backend.Application.Security;
using NoteBucket.Backend.Base.Security.Claims;
using NoteBucket.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Application.Modules
{
    public class NoteModule : NancyModule
    {
        public NoteModule(
            IAuthenticationContext authContext, 
            INoteService noteService,
            IFolderService folderService)
            : base("/api/note")
        {
            // Ensure notes API is only accessed by authenticated users.
            StatelessAuthentication.Enable(this, new StatelessAuthenticationConfiguration(authContext.GetUser));
            this.RequiresAuthentication();

            Put["/"] = p =>
            {
                var dto = this.Bind<NoteDto>();
                var note = noteService.GetById(dto.Id);
                this.RequiresClaims(AccessClaim.Get(note.Folder.Owner.Id));
                note.Body = dto.Body;
                note.Title = dto.Title;
                return HttpStatusCode.OK;
            };

            Get["/{noteId}"] = p =>
            {
                // Ensure the request is allowed to see the specific note 
                var note = noteService.GetById((int)p.noteId);
                this.RequiresClaims(AccessClaim.Get(note.Folder.Owner.Id));

                var result = GetNoteViewData(note);
                return new JsonResponse(result, new DefaultJsonSerializer());
            };

            Get["/folder/{folderId}"] = p =>
            {
                // Ensure the request is allowed to see the notes of the owner
                var folderId = (int)p.folderId;
                var folder = folderService.GetById(folderId);
                this.RequiresClaims(AccessClaim.Get(folder.Owner.Id));

                var notes = noteService.GetByFolder(folderId);
                var result = notes.Select(n => 
                    {
                        return GetNoteViewData(n);
                    }).ToList();
                return new JsonResponse(result, new DefaultJsonSerializer());
            };
        }

        private dynamic GetNoteViewData(Note note)
        {
            return new
            {
                Id = note.Id,
                Title = note.Title,
                Body = note.Body,
                Folder = new
                {
                    Id = note.Folder.Id
                },
                Owner = new
                {
                    Id = note.Folder.Owner.Id
                }
            };
        }
    }
}
