using Pointwise.Domain.Models;
using Pointwise.Domain.ValidationRules;
using Pointwise.Web.Admin.ValidatorAttributes;
using System.ComponentModel.DataAnnotations;

namespace Pointwise.Web.Admin.ViewModels
{
    public partial class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CategoryValidator.Name.IsRequiredErrorMessage)]
        [StringLength(CategoryValidator.Name.MaxLength, ErrorMessage = CategoryValidator.Name.MaxLenghtErrorMessage)]
        public string Name { get; set; }
    }

    public partial class CategoryViewModel
    {
        public Category ToDomainEntity()
        {
            return new Category
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}