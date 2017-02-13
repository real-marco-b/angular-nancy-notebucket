using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Security;
using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Application.Security;
using NoteBucket.Backend.Base.Security.Claims;
using System.Linq;

namespace NoteBucket.Backend.Application.Modules
{
    public class FolderModule : NancyModule
    {
        public FolderModule(
            IAuthenticationContext authContext, 
            IFolderService folderService,
            INoteService noteService)
            : base("/api/folder")
        {
            // Ensure folders API is only accessed by authenticated users
            StatelessAuthentication.Enable(this, new StatelessAuthenticationConfiguration(authContext.GetUser));
            this.RequiresAuthentication();

            Get["/owner/{ownerId}"] = p =>
            {
                // Ensure the request is allowed to see the folders of the owner
                var ownerId = (int)p.ownerId;
                this.RequiresClaims(AccessClaim.Get(ownerId));

                var folders = folderService.GetByOwner(ownerId);
                var result = folders.Select(f => new
                {
                    Id = f.Id,
                    Name = f.Name,
                    Owner = new
                    {
                        Id = f.Owner.Id
                    },
                    Notes = noteService.GetByFolder(f.Id).Select(n => new
                    {
                        Id = n.Id,
                        Title = n.Title
                    }).ToList()
                }).ToList();
                return new JsonResponse(result, new DefaultJsonSerializer());
            };
        }
    }
}
