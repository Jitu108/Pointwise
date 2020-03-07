using Pointwise.Domain.Enums;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.Interfaces
{
    public interface IUser : IBaseEntity
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumber { get; set; }
        IUserType UserType { get; set; }
        UserNameType UserNameType { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsBlocked { get; set; }
    }
}
