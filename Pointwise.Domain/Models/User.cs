using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;

namespace Pointwise.Domain.Models
{
    public sealed class User : BaseEntity, IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public UserNameType UserNameType { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
    }
}
