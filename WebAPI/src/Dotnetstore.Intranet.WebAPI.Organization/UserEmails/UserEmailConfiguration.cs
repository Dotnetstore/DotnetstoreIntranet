using Dotnetstore.Intranet.WebAPI.Organization.Enums;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;
using Dotnetstore.Intranet.WebAPI.Utility.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserEmails;

internal sealed class UserEmailConfiguration : BaseAuditableEntityConfiguration<UserEmail>
{
    public override void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserEmailId, Guid>(
            id => id.Value, 
            guid => new UserEmailId(guid));
        
        var userIdConverter = new ValueConverter<UserId, Guid>(
            id => id.Value, 
            guid => new UserId(guid));
        
        var emailTypeConverter = new ValueConverter<EmailType, Guid>(
            id => id.Id,
            guid => Enumeration.FromValue<EmailType>(guid));
        
        builder
            .HasKey(x => x.UserEmailId);
        
        builder
            .HasIndex(x => x.UserEmailId)
            .IsUnique()
            .HasDatabaseName("Index_Id");
        
        builder
            .HasIndex(x => x.IsDeleted)
            .HasDatabaseName("Index_IsDeleted");

        builder
            .Property(x => x.UserEmailId)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .HasConversion(userIdConverter)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.EmailType)
            .HasConversion(emailTypeConverter)
            .IsRequired();

        builder
            .Property(x => x.EmailAddress)
            .HasMaxLength(255)
            .IsRequired()
            .IsUnicode(false);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserEmails)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}