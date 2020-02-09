using System;
using System.Collections.Generic;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;

namespace Pointwise.Domain.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository repository;

        public ImageService(IImageRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public IEnumerable<IImage> GetImages()
        {
            return repository.GetImages();
        }

        public IImage GetImageById(int id)
        {
            return repository.GetImageById(id);
        }

        public IEnumerable<IImage> GetImageByName(string searchString)
        {
            return repository.GetImageByName(searchString);
        }

        public IEnumerable<IImage> GetImageByName(string searchString, Extension extension)
        {
            return repository.GetImageByName(searchString, extension);
        }

        public IEnumerable<IImage> GetImageByExtension(Extension extension)
        {
            return repository.GetImageByExtension(extension);
        }
    }
}
