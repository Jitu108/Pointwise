using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.SqlDataAccess.Interfaces;

namespace Pointwise.SqlDataAccess.Models
{
    public partial class Source : BaseEntity, ISource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Source : IConvert<Domain.Models.Source>
    {
        public Domain.Models.Source ToDomainEntity()
        {
            return new Domain.Models.Source
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
