using Pointwise.Domain.Interfaces;
using System.Collections.Generic;
using System.Web;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IImageService
    {
        string GetImageById(int id);
        IImage SaveImage(HttpPostedFileBase postedFile);

        IImage Add(Models.Image entity);

        IEnumerable<IImage> AddRange(IEnumerable<Models.Image> entities);
        IEnumerable<IImage> AddRange(IEnumerable<Models.Image> entities, int articleId);
        void Delete(int id);

        void DeleteRange(IEnumerable<Models.Image> entities);
        void SoftDelete(int id);
        void UndoSoftDelete(int id);
        void SoftDeleteRange(IEnumerable<Models.Image> entities);

        IImage Update(Models.Image entity);
        IEnumerable<IImage> Update(IEnumerable<Models.Image> entities, int articleId);
    }
}
