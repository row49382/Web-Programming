using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinalProject.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private SecurityProvider securityProvider;

        public AuthorizationFilter(SecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
        }

        // Bearer: <your token>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues authHeader;
            if (!context.HttpContext.Request.Headers.TryGetValue("authorization", out authHeader))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                return;
            }
            var authorization = authHeader[0];
            if (!authorization.StartsWith("Bearer: "))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                return;
            }

            // peel off bearer
            authorization = authorization.Substring(8);

            // now call validate token from ISecurityProvider class
            if (!securityProvider.ValidateToken(authorization))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
            }

        }
    }
}
