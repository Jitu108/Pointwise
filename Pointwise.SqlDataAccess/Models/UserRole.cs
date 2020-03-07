using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.SqlDataAccess.Interfaces;
using System.Collections.Generic;

namespace Pointwise.SqlDataAccess.Models
{
    public partial class SqlUserRole : BaseEntity, IUserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
    }
    public partial class SqlUserRole : IConvert<Domain.Models.UserRole>
    {
        public Domain.Models.UserRole ToDomainEntity()
        {
            return new Domain.Models.UserRole
            {
                Id = this.Id,
                Name = this.Name,
                CreatedOn = this.CreatedOn,
                LastModifiedOn = this.LastModifiedOn,
                IsDeleted = this.IsDeleted
            };
        }
    }
}
