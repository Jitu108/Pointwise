using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace Pointwise.Domain.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository repository;

        public UserTypeService(IUserTypeRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserType> GetUserTypes()
        {
            return repository.GetAll();
        }

        public IUserType GetById(int id)
        {
            return repository.GetById(id);
        }

        public IUserType Add(UserType entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<IUserType> AddRange(IEnumerable<UserType> entities)
        {
            return repository.AddRange(entities);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public bool DeleteRange(IEnumerable<UserType> entities)
        {
            return repository.DeleteRange(entities);
        }

        public IUserType Update(UserType entity)
        {
            return repository.Update(entity);
        }

        public bool SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public bool UndoSoftDelete(int id)
        {
            return repository.UndoSoftDelete(id);
        }

        public bool SoftDeleteRange(IEnumerable<UserType> entities)
        {
            return repository.SoftDeleteRange(entities);
        }
    }
}
