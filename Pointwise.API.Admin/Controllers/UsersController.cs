using Pointwise.Domain.Models;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pointwise.API.Admin.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = userService.GetById(id);

                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Sources
        [HttpPost]
        public IHttpActionResult Create([FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var addedEntity = userService.Add(user);
                return CreatedAtRoute("DefaultApi", new { id = addedEntity.Id }, addedEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody]Models.LoginDTO loginData)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (loginData == null) return BadRequest(nameof(loginData));

                var user = userService.Login(loginData.UserName, loginData.Password);

                if (user != null) return Ok(user);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Sources/5
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (user == null) return BadRequest(nameof(user));

                user.Id = id;
                var updatedEntity = userService.Update(user);

                if (updatedEntity != null) return Ok(updatedEntity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
