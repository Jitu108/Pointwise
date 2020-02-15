using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public class SqlSourceRepository : ISourceRepository
    {
        private readonly PointwiseSqlContext context;

        public SqlSourceRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<ISource> GetSources()
        {
            return context.Sources.AsEnumerable().Select(x => x.ToDomainEntity());
        }

        public ISource GetById(int id)
        {
            return context.Sources.Find(id).ToDomainEntity();
        }

        public ISource Add(Source entity)
        {
            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Sources.Add(sEntity);
            context.SaveChanges();

            return insertedRow.ToDomainEntity();
        }

        public IEnumerable<ISource> AddRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Sources.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public void Remove(int id)
        {
            var sEntity = context.Sources.SingleOrDefault(x => x.Id == id);
            //context.Sources.Remove(sEntity);
            sEntity.IsDeleted = true;
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            //context.Sources.RemoveRange(sEntities);
            foreach(var source in sEntities)
            {
                source.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void HardRemove(int id)
        {
            var sEntity = context.Sources.SingleOrDefault(x => x.Id == id);
            context.Sources.Remove(sEntity);
            context.SaveChanges();
        }

        public void HardRemoveRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Sources.RemoveRange(sEntities);
            context.SaveChanges();
        }

        public ISource Update(Source entity)
        {
            var sEntity = context.Sources.Find(entity.Id);
            sEntity.Name = entity.Name;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }
    }
}
