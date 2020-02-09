using System;
using System.Collections.Generic;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IImageService
    {
        IEnumerable<IImage> GetImages();
        IImage GetImageById(int id);
        IEnumerable<IImage> GetImageByName(string searchString);
        IEnumerable<IImage> GetImageByName(string searchString, Extension extension);
        IEnumerable<IImage> GetImageByExtension(Extension extension);
    }
}
