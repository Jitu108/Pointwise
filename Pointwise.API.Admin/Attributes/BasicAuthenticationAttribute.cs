using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Pointwise.API.Admin.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private readonly IAuthenticationService authService;
        public BasicAuthenticationAttribute(IAuthenticationService authService)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext
                    .Request
                    .CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                var authenticationToken = actionContext.Request
                    .Headers.Authorization.Parameter;

                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                var usernamePasswordArray = decodedAuthenticationToken.Split(':');

                var username = usernamePasswordArray[0];
                var password = usernamePasswordArray[1];

                if (authService.Login(username, password) != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext
                    .Request
                    .CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}