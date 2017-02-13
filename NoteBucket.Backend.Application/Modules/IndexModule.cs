using Nancy;
using Nancy.Responses;

namespace NoteBucket.Backend.Application.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base("")
        {
            Get["/"] = _ =>
            {
                return new GenericFileResponse("Content/index.html", "text/html");
            };

            Get[@"/(.*)"] = _ =>
            {
                return new GenericFileResponse("Content/index.html", "text/html");
            };
        }
    }
}
