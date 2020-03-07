using Pointwise.Domain.Interfaces;
using System.Collections.Generic;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.Repositories
{
    public interface IArticleRepository : IRepository<IArticle, Article>
    {
    }
}
