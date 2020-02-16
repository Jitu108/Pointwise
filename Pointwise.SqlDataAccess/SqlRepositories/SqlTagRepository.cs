using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    class SqlTagRepository : ITagRepository
    {
        private readonly PointwiseSqlContext context;

        public SqlTagRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<ITag> GetTags()
        {
            var tags = context.Tags.AsEnumerable().Select(x => x.ToDomainEntity()).ToList();
            return tags;
        }

        public ITag GetById(int id)
        {
            return context.Tags.Find(id).ToDomainEntity();
        }

        public ITag Add(Domain.Models.Tag entity)
        {
            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Tags.Add(sEntity);
            context.SaveChanges();

            return insertedRow.ToDomainEntity();
        }

        public IEnumerable<ITag> AddRange(IEnumerable<Domain.Models.Tag> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Tags.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public void Remove(int id)
        {
            var sEntity = context.Tags.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = true;
            //context.Categories.Remove(sEntity);
            context.SaveChanges();
            var sEntity1 = context.Tags.SingleOrDefault(x => x.Id == id);

        }

        public void RemoveRange(IEnumerable<Domain.Models.Tag> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            //context.Categories.RemoveRange(sEntities);
            foreach (var entity in sEntities)
            {
                entity.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void HardRemove(int id)
        {
            var sEntity = context.Tags.SingleOrDefault(x => x.Id == id);
            context.Tags.Remove(sEntity);
            context.SaveChanges();
        }

        public void HardRemoveRange(IEnumerable<Domain.Models.Tag> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Tags.RemoveRange(sEntities);

            context.SaveChanges();
        }

        public ITag Update(Domain.Models.Tag entity)
        {
            var sEntity = context.Tags.Find(entity.Id);
            sEntity.Name = entity.Name;
            sEntity.LastModifiedOn = DateTime.Now;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }
    }
}
