using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public sealed class SqlUserRepository : IUserRepository, IDisposable
    {
        private readonly PointwiseSqlContext context;

        public SqlUserRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IUser Add(Domain.Models.User entity)
        {
            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Users.Add(sEntity);
            context.SaveChanges();

            return insertedRow.ToDomainEntity();
        }

        public IEnumerable<IUser> AddRange(IEnumerable<Domain.Models.User> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Users.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public void SoftDelete(int id)
        {
            var sEntity = context.UserRoles.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = true;
            context.SaveChanges();
        }

        public void UndoSoftDelete(int id)
        {
            var sEntity = context.UserRoles.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = false;
            context.SaveChanges();
        }

        public void SoftDeleteRange(IEnumerable<Domain.Models.User> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            foreach (var entity in sEntities)
            {
                entity.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sEntity = context.Users.SingleOrDefault(x => x.Id == id);
            context.Users.Remove(sEntity);
            context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<Domain.Models.User> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Users.RemoveRange(sEntities);

            context.SaveChanges();
        }

        public IUser Update(Domain.Models.User entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var sEntity = context.Users.Find(entity.Id);
            sEntity.FirstName = entity.FirstName;
            sEntity.MiddleName = entity.MiddleName;
            sEntity.LastName = entity.LastName;
            sEntity.EmailAddress = entity.EmailAddress;
            sEntity.PhoneNumber = entity.PhoneNumber;
            sEntity.UserType = entity.UserType;
            sEntity.UserNameType = entity.UserNameType;
            sEntity.UserName = entity.UserName;
            sEntity.Password = entity.Password;
            sEntity.IsBlocked = entity.IsBlocked;
            sEntity.LastModifiedOn = DateTime.Now;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }

        public IEnumerable<IUser> GetAll()
        {
            var users = context.Users.AsEnumerable().Select(x => x.ToDomainEntity()).ToList();
            return users;
        }

        public IUser GetById(int id)
        {
            return context.Users.Find(id).ToDomainEntity();
        }

        public IUser Login(string userName, string password)
        {
            var user = context.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            return user;
        }

        public bool Logout(string userName)
        {
            var userExists = context.Users.SingleOrDefault(x => x.UserName == userName);
            return userExists != null;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}