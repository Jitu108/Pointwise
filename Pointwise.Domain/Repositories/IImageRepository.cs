using Pointwise.Domain.Interfaces;
using System.Collections.Generic;
using Pointwise.Domain.Enums;

namespace Pointwise.Domain.Repositories
{
    public interface IImageRepository
    {
        IEnumerable<IImage> GetImages();
        IImage GetImageById(int id);

        IEnumerable<IImage> GetImageByName(string searchString);

        IEnumerable<IImage> GetImageByName(string searchString, Extension extension);

        IEnumerable<IImage> GetImageByExtension(Extension extension);

    }
}
