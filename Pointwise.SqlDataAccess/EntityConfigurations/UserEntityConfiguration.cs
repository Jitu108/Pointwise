using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            // Table Name
            ToTable("Users");

            // PK
            HasKey(x => x.Id);

            

            // Property Configurations

            if (UserValidator.FirstName.IsRequired)
            {
                Property(x => x.FirstName).IsRequired();
            }
            Property(x => x.FirstName)
                .HasMaxLength(UserValidator.FirstName.MaxLength);

            //---------------------------------------------------
            if (UserValidator.MiddleName.IsRequired)
            {
                Property(x => x.MiddleName).IsRequired();
            }
            Property(x => x.MiddleName)
                .HasMaxLength(UserValidator.MiddleName.MaxLength);

            //---------------------------------------------------
            if (UserValidator.LastName.IsRequired)
            {
                Property(x => x.LastName).IsRequired();
            }
            Property(x => x.LastName)
                .HasMaxLength(UserValidator.LastName.MaxLength);

            //---------------------------------------------------
            if (UserValidator.EmailAddress.IsRequired)
            {
                Property(x => x.EmailAddress).IsRequired();
            }
            Property(x => x.EmailAddress)
                .HasMaxLength(UserValidator.EmailAddress.MaxLength);

            //---------------------------------------------------
            if (UserValidator.PhoneNumber.IsRequired)
            {
                Property(x => x.PhoneNumber).IsRequired();
            }
            Property(x => x.PhoneNumber)
                .HasMaxLength(UserValidator.PhoneNumber.MaxLength);

            //---------------------------------------------------
            if (UserValidator.UserType.IsRequired)
            {
                Property(x => x.UserTypeId).IsRequired();
            }

            HasRequired(x => x.SqlUserType)
                .WithMany()
                .HasForeignKey(x => x.UserTypeId);

            HasMany(u => u.SqlUserRoles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("UserRoles");
                });
                

            //---------------------------------------------------
            if (UserValidator.UserNameType.IsRequired)
            {
                Property(x => x.UserNameType).IsRequired();
            }

            //---------------------------------------------------
            if (UserValidator.UserName.IsRequired)
            {
                Property(x => x.UserName).IsRequired();
            }
            Property(x => x.UserName)
                .HasMaxLength(UserValidator.UserName.MaxLength);

            //---------------------------------------------------
            if (UserValidator.Password.IsRequired)
            {
                Property(x => x.Password).IsRequired();
            }
            Property(x => x.Password)
                .HasMaxLength(UserValidator.Password.MaxLength);

            //---------------------------------------------------
            if (UserValidator.IsBlocked.IsRequired)
            {
                Property(x => x.IsBlocked).IsRequired();
            }

            //---------------------------------------------------

            // Common Property Configurations
            Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation("Default", 0);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.LastModifiedOn)
                .IsOptional();
        }
    }
}