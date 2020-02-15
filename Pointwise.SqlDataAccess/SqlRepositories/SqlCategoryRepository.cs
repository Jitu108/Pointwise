using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using Pointwise.SqlDataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly PointwiseSqlContext context;

        public SqlCategoryRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<ICategory> GetCategories()
        {
            return context.Categories.AsEnumerable().Select(x => x.ToDomainEntity());
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

        public void Remove(int id)
        {
            var sEntity = context.Categories.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = true;
            //context.Categories.Remove(sEntity);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Domain.Models.Category> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            //context.Categories.RemoveRange(sEntities);
            foreach(var entity in sEntities)
            {
                entity.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void HardRemove(int id)
        {
            var sEntity = context.Categories.SingleOrDefault(x => x.Id == id);
            context.Categories.Remove(sEntity);
            context.SaveChanges();
        }

        public void HardRemoveRange(IEnumerable<Domain.Models.Category> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Categories.RemoveRange(sEntities);
            
            context.SaveChanges();
        }

        public ICategory Update(Domain.Models.Category entity)
        {
            var sEntity = context.Categories.Find(entity.Id);
            sEntity.Name = entity.Name;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }
    }
}
