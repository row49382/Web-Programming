using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Assignment6.Services;

namespace Assignment6_2017.Controllers
{
    public class ErrorsController : Controller
    {
        private IConsoleLogger loggingService;
        private IRequestGenerator RequestIdGenerator;

        public ErrorsController(IConsoleLogger loggingService, IRequestGenerator RequestIdGenerator)
        {
            this.loggingService = loggingService;
            this.RequestIdGenerator = RequestIdGenerator;
        }

        [Route("/Error")]
        public void Index()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            var generator = this.RequestIdGenerator;
            this.loggingService.Log(error?.ToString());

        }
    }
}
