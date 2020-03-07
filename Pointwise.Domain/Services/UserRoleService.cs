using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace Pointwise.Domain.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository repository;

        public UserRoleService(IUserRoleRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserRole> GetUserRoles()
        {
            return repository.GetAll();
        }

        public IUserRole GetById(int id)
        {
            return repository.GetById(id);
        }

        public IUserRole Add(UserRole entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<IUserRole> AddRange(IEnumerable<UserRole> entities)
        {
            return repository.AddRange(entities);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void DeleteRange(IEnumerable<UserRole> entities)
        {
            repository.DeleteRange(entities);
        }

        public void SoftDelete(int id)
        {
            repository.SoftDelete(id);
        }

        public void UndoSoftDelete(int id)
        {
            repository.UndoSoftDelete(id);
        }

        public void SoftDeleteRange(IEnumerable<UserRole> entities)
        {
            repository.SoftDeleteRange(entities);
        }

        public IUserRole Update(UserRole entity)
        {
            return repository.Update(entity);
        }
    }
}
    