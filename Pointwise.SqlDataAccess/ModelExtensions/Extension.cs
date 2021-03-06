﻿using Pointwise.SqlDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel = Pointwise.Domain.Models;

namespace Pointwise.SqlDataAccess.ModelExtensions
{
    public static class Extension
    {
        public static Category ToPersistentEntity(this DomainModel.Category entity)
        {
            if (entity == null) return null; //throw new ArgumentNullException(nameof(entity));

            return new Category
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Source ToPersistentEntity(this DomainModel.Source entity)
        {
            if (entity == null) return null; //throw new ArgumentNullException(nameof(entity));

            return new Source
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Article ToPersistentEntity(this DomainModel.Article entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var article = new Article
            {
                Id = entity.Id,
                Author = entity.Author,
                Title = entity.Title,
                Summary = entity.Summary,
                Url = entity.Url,
                PublicationDate = entity.PublicationDate,
                Content = entity.Content,
                Synopsis = entity.Synopsis,
                SqlSource = ((DomainModel.Source)entity.Source).ToPersistentEntity(),
                SqlCategory = ((DomainModel.Category)entity.Category).ToPersistentEntity(),
                AssetType = entity.AssetType,
                SqlTags = entity.Tags != null? entity.Tags.Select(x => ((DomainModel.Tag)x).ToPersistentEntity()).ToList(): new List<Tag>(),
                SqlImages = entity.Images != null? entity.Images.Select(x => ((DomainModel.Image)x).ToPersistentEntity()).ToList() : new List<Image>()
            };
            return article;
        }
        public static Tag ToPersistentEntity(this Domain.Models.Tag entity)
        {
            if (entity == null) return null; // throw new ArgumentNullException(nameof(entity));

            return new Tag
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static SqlUserRole ToPersistentEntity(this Domain.Models.UserRole entity)
        {
            return new SqlUserRole
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static SqlUserType ToPersistentEntity(this Domain.Models.UserType entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new SqlUserType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static User ToPersistentEntity(this Domain.Models.User entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumber,
                UserType = entity.UserType,
                UserNameType = entity.UserNameType,
                UserName = entity.UserName,
                Password = entity.Password,
                IsBlocked = entity.IsBlocked,
                
            };
        }

        public static Image ToPersistentEntity(this Domain.Models.Image entity)
        {
            if (entity == null) return null; //throw new ArgumentNullException(nameof(entity));

            return new Image
            {
                Id = entity.Id,
                Name = entity.Name,
                Path = entity.Path,
                ContentType = entity.ContentType,
                Data = entity.Data,
                Extension = entity.Extension,
                SavedTo = entity.SavedTo
            };
        }
    }
}
