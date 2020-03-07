using Pointwise.Domain.Interfaces;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Net;
using System.Web.Http;

namespace Pointwise.API.Admin.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost]
        [Route("Authentication/Login")]
        public IUser Login([FromBody]string username, [FromBody]string password)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var user = authService.Login(username, password);

            return user;
        }

        [HttpPost]
        [Route("Authentication/Logout")]
        public void Logout(string username)
        {
            authService.Logout(username);
        }
    }
}
