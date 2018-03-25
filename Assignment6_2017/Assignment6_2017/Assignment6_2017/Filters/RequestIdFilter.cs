using Assignment6.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment6.Filters
{
	public class RequestIdFilter : IActionFilter
    {
		private string localId;

        private IConsoleLogger loggingService;
        private IRequestGenerator requestId;

		public RequestIdFilter(IConsoleLogger loggingService, IRequestGenerator requestID)
		{
            this.requestId = requestID;
            this.loggingService = loggingService;
        }

		public void OnActionExecuted(ActionExecutedContext context)
		{
            /*
			* TODO: This should use an IRequestIdGenerator, which is an interface that still needs to be created.
			*/
            localId = requestId.Generate();
			this.loggingService.Log("Adding a request-id to the response: " + this.localId);
			context.HttpContext.Response.Headers.Add("request-id", new string[] { this.localId });
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			// nothing to do here, but have to have this method because the interface requires it
		}
	}
}
