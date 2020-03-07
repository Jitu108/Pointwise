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

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void DeleteRange(IEnumerable<UserType> entities)
        {
            repository.DeleteRange(entities);
        }

        public IUserType Update(UserType entity)
        {
            return repository.Update(entity);
        }

        public void SoftDelete(int id)
        {
            repository.SoftDelete(id);
        }

        public void UndoSoftDelete(int id)
        {
            repository.UndoSoftDelete(id);
        }

        public void SoftDeleteRange(IEnumerable<UserType> entities)
        {
            repository.SoftDeleteRange(entities);
        }
    }
}
