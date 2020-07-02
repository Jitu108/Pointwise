﻿using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using System;
using Pointwise.SqlDataAccess.ModelExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public sealed class SqlImageRepository : IImageRepository, IDisposable
    {
        private readonly PointwiseSqlContext context;

        public SqlImageRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }
        public IImage GetById(int id)
        {
            return context.Images.Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<IImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IImage Add(Image entity)
        {
            

            return AddImage(entity).ToDomainEntity();
        }

        private Models.Image AddImage(Image entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Images.Add(sEntity);

            context.SaveChanges();
            return insertedRow;
        }

        public IEnumerable<IImage> AddRange(IEnumerable<Image> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Images.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public IEnumerable<IImage> AddRange(IEnumerable<Image> images, int? articleId)
        {
            if (images == null) throw new ArgumentNullException(nameof(images));

            if (articleId != null)
            {
                foreach (var image in images)
                {
                    image.ArticleId = articleId.Value;
                }
            }

            var sEntities = images.Select(x => x.ToPersistentEntity()).ToList();
            var insertedRows = context.Images.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();

        }

        public bool Delete(int id)
        {
            var sEntity = context.Images.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;

            context.Images.Remove(sEntity);
            context.SaveChanges();
            return true;
        }

        public bool DeleteRange(IEnumerable<Image> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Images.RemoveRange(sEntities);
            context.SaveChanges();
            return true;
        }

        public bool SoftDelete(int id)
        {
            var sEntity = context.Images.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;

            sEntity.IsDeleted = true;
            context.SaveChanges();
            return true;
        }

        public bool UndoSoftDelete(int id)
        {
            var sEntity = context.Images.SingleOrDefault(x => x.Id == id);
            if (sEntity == null) return false;

            sEntity.IsDeleted = false;
            context.SaveChanges();
            return true;
        }

        public bool SoftDeleteRange(IEnumerable<Image> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            foreach (var image in sEntities)
            {
                image.IsDeleted = true;
            }
            context.SaveChanges();
            return true;
        }

        public IImage Update(Image entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var sEntity = context.Images.Find(entity.Id);
            sEntity.Name = entity.Name;
            sEntity.Path = entity.Path;
            sEntity.ContentType = entity.ContentType;
            sEntity.Data = entity.Data;
            sEntity.Extension = entity.Extension;
            sEntity.SavedTo = entity.SavedTo;
            sEntity.ArticleId = entity.ArticleId;

            sEntity.LastModifiedOn = DateTime.Now;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }

        public IEnumerable<IImage> Update(IEnumerable<IImage> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            
            var now = DateTime.Now;
            var sEntites = new List<Models.Image>();
            foreach (var entity in entities)
            {
                if (entity.Id == 0)
                {
                    var sEntity = AddImage((Image)entity);
                    sEntites.Add(sEntity);
                }
                else
                {
                    var sEntity = context.Images.Find(entity.Id);
                    sEntity.Name = entity.Name;
                    sEntity.Path = entity.Path;
                    sEntity.ContentType = entity.ContentType;
                    sEntity.Data = entity.Data;
                    sEntity.Extension = entity.Extension;
                    sEntity.SavedTo = entity.SavedTo;
                    sEntity.ArticleId = entity.ArticleId;

                    sEntity.LastModifiedOn = now;
                    context.SaveChanges();
                    sEntites.Add(sEntity);
                }
            }
            return sEntites.Select(x => x.ToDomainEntity()).ToList();
        }
    }
}
