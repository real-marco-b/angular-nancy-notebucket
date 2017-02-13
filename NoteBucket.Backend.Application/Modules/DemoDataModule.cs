using Nancy;
using NoteBucket.Backend.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Application.Modules
{
    public class DemoDataModule : NancyModule
    {
        public DemoDataModule(IDemoDataService service) : base("/api/demo")
        {
            Get["/"] = _ =>
            {
                service.CreateDemoData();
                return HttpStatusCode.OK;
            };
        }
    }
}
