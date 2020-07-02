using System;
using System.Linq;
using System.Collections.Generic;

using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public sealed class SqlSourceRepository : ISourceRepository, IDisposable
    {
        private readonly PointwiseSqlContext context;

        public SqlSourceRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<ISource> GetAll()
        {
            return context.Sources.AsEnumerable().Select(x => x.ToDomainEntity());
        }

        public ISource GetById(int id)
        {
            return context.Sources.Find(id).ToDomainEntity();
        }

        public ISource Add(Source entity)
        {
            try
            {
                var sEntity = entity.ToPersistentEntity();
                var insertedRow = context.Sources.Add(sEntity);
                context.SaveChanges();

                return insertedRow.ToDomainEntity();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public IEnumerable<ISource> AddRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Sources.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public bool SoftDelete(int id)
        {
            var sEntity = context.Sources.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;
            sEntity.IsDeleted = true;
            context.SaveChanges();
            return true;
        }

        public bool UndoSoftDelete(int id)
        {
            var sEntity = context.Sources.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;
            sEntity.IsDeleted = false;
            context.SaveChanges();
            return true;
        }

        public bool SoftDeleteRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            foreach(var source in sEntities)
            {
                source.IsDeleted = true;
            }
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var sEntity = context.Sources.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;

            context.Sources.Remove(sEntity);
            context.SaveChanges();
            return true;
        }

        public bool DeleteRange(IEnumerable<Source> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Sources.RemoveRange(sEntities);
            context.SaveChanges();
            return true;
        }

        public ISource Update(Source entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var sEntity = context.Sources.Find(entity.Id);
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
