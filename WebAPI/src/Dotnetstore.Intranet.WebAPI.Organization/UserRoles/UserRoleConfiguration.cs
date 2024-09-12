﻿using Dotnetstore.Intranet.WebAPI.Utility.Entities;
using Dotnetstore.Intranet.WebAPI.Utility.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserRoles;

internal sealed class UserRoleConfiguration : BaseAuditableEntityConfiguration<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserRoleId, Guid>(
            id => id.Value, 
            guid => new UserRoleId(guid));
        
        builder
            .HasKey(x => x.UserRoleId);

        builder
            .HasIndex(x => x.UserRoleId)
            .IsUnique()
            .HasDatabaseName("Index_Id");
        
        builder
            .HasIndex(x => x.IsDeleted)
            .HasDatabaseName("Index_IsDeleted");

        builder
            .Property(x => x.UserRoleId)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired()
            .IsUnicode();

        builder
            .HasData(
                new UserRole
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "Administrator",
                    UserRoleId = new UserRoleId(Constants.UserRoleAdministratorId)
                },
                new UserRole
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "Super user",
                    UserRoleId = new UserRoleId(Constants.UserRoleSuperUserId)
                },
                new UserRole
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "User",
                    UserRoleId = new UserRoleId(Constants.UserRoleUserId)
                });
    }
}