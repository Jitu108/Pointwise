using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.SqlDataAccess.Interfaces;

namespace Pointwise.SqlDataAccess.Models
{
    public partial class Category : BaseEntity, ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Category : IConvert<Domain.Models.Category>
    {
        public Domain.Models.Category ToDomainEntity()
        {
            return new Domain.Models.Category
            {
                Id = this.Id,
                Name = this.Name,
                CreatedOn = this.CreatedOn,
                LastModifiedOn = this.LastModifiedOn,
                IsDeleted = this.IsDeleted
            };
        }

        //public static Category ToPersistentEntity(ICategory entity)
        //{
        //    return new Category
        //    {
        //        Id = entity.Id,
        //        Name = entity.Name
        //    };
        //}
    }
}
