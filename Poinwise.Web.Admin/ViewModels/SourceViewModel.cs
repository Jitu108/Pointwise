using Pointwise.Domain.Models;
using Pointwise.Domain.ValidationRules;
using System.ComponentModel.DataAnnotations;

namespace Pointwise.Web.Admin.ViewModels
{
    public partial class SourceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = SourceValidator.Name.IsRequiredErrorMessage)]
        [StringLength(SourceValidator.Name.MaxLength, ErrorMessage = SourceValidator.Name.MaxLenghtErrorMessage)]
        public string Name { get; set; }
    }

    public partial class SourceViewModel
    {
        public Source ToDomainEntity()
        {
            return new Source
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}