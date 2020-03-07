using System;
using System.Linq;
using System.Collections.Generic;

using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using Pointwise.SqlDataAccess.Models;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public sealed class SqlCategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly PointwiseSqlContext context;

        public SqlCategoryRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<ICategory> GetAll()
        {
            var categories = context.Categories.AsEnumerable().Select(x => x.ToDomainEntity()).ToList();
            return categories;
        }

        public ICategory GetById(int id)
        {
            return context.Categories.Find(id).ToDomainEntity();
        }

        public ICategory Add(Domain.Models.Category entity)
        {
            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Categories.Add(sEntity);
            context.SaveChanges();

            return insertedRow.ToDomainEntity();
        }

        public IEnumerable<ICategory> AddRange(IEnumerable<Domain.Models.Category> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Categories.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public void SoftDelete(int id)
        {
            var sEntity = context.Categories.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = true;
            context.SaveChanges();

        }

        public void UndoSoftDelete(int id)
        {
            var sEntity = context.Categories.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = false;
            context.SaveChanges();
        }

        public void SoftDeleteRange(IEnumerable<Domain.Models.Category> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            foreach(var entity in sEntities)
            {
                entity.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sEntity = context.Categories.SingleOrDefault(x => x.Id == id);
            context.Categories.Remove(sEntity);
            context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<Domain.Models.Category> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Categories.RemoveRange(sEntities);
            
            context.SaveChanges();
        }

        public ICategory Update(Domain.Models.Category entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var sEntity = context.Categories.Find(entity.Id);
            sEntity.Name = entity.Name;
            sEntity.LastModifiedOn = DateTime.Now;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        
    }
}
