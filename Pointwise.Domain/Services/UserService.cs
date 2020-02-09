using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;

namespace Pointwise.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }
        public IEnumerable<IUser> GetAllUsers()
        {
            return repository.GetAllUsers();
        }
        public IUser GetUserById(int id)
        {
            return repository.GetUserById(id);
        }
        public IEnumerable<IUser> GetUserByName(string nameString)
        {
            return repository.GetUserByName(nameString);
        }
        public IEnumerable<IUser> GetUserByEmailAddress(string emailString)
        {
            return repository.GetUserByEmailAddress(emailString);
        }
        public IEnumerable<IUser> GetUserByPhoneNumber(string phoneString)
        {
            return repository.GetUserByPhoneNumber(phoneString);
        }
        public IEnumerable<IUser> GetBlockedUsers()
        {
            return repository.GetBlockedUsers();
        }
        public bool UserIsBlocked(IUser user)
        {
            return repository.UserIsBlocked(user);
        }
    }
}
