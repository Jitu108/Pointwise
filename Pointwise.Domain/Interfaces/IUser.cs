using Pointwise.Domain.Enums;

namespace Pointwise.Domain.Interfaces
{
    public interface IUser : IBaseEntity
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumber { get; set; }
        UserType UserType { get; set; }
        UserNameType UserNameType { get; set; }
        string Password { get; set; }
        bool IsBlocked { get; set; }
    }
}
