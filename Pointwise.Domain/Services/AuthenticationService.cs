using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using System;

namespace Pointwise.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository repository;

        public AuthenticationService(IUserRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public IUser Login(string userName, string password)
        {
            var user = repository.Login(userName, password);
            return user;
        }

        public bool Logout(string userName)
        {
            return repository.Logout(userName);
        }
    }
}
