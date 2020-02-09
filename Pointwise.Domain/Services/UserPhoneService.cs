using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;

namespace Pointwise.Domain.Services
{
    public class UserPhoneService : IUserPhoneService
    {
        private readonly IUserPhoneRepository repository;

        public UserPhoneService(IUserPhoneRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }
        public IEnumerable<IUserPhone> GetAllUserPhones(int userId)
        {
            return repository.GetAllUserPhones(userId);
        }
        public IEnumerable<IUserPhone> GetUserPrimaryPhone(int userId)
        {
            return repository.GetUserPrimaryPhone(userId);
        }
    }
}
