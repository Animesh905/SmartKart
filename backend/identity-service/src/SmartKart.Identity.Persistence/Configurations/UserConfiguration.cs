using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartKart.Identity.Domain.Entities.RoleEntities;
using SmartKart.Identity.Domain.Entities.UserEntities;
using SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;
using SmartKart.Identity.Persistence.Constants;

namespace SmartKart.Identity.Persistence.Configurations;

internal sealed class UserConfiguration 
    : IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.tbl_Users);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.IsActive)
               .IsRequired();

        builder.Property(x => x.IsEmailVerified)
               .IsRequired();

        ConfigureFirstName(builder);

        ConfigureMiddleName(builder);

        ConfigureLastName(builder);

        ConfigureEmail(builder);

        ConfigurePhoneNumber(builder);

        ConfigureRoles(builder);
    }

    private static void ConfigureFirstName(
    EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
               .HasConversion(
                   x => x.Value,
                   v => FirstName.Create(v).Value)
               .HasMaxLength(FirstName.MaxLength)
               .IsRequired();
    }

    private static void ConfigureMiddleName(
    EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.MiddleName)
               .HasConversion(
                   x => x.Value,
                   v => MiddleName.Create(v).Value)
               .HasMaxLength(MiddleName.MaxLength);
    }

    private static void ConfigureLastName(
    EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.LastName)
               .HasConversion(
                   x => x.Value,
                   v => LastName.Create(v).Value)
               .HasMaxLength(LastName.MaxLength)
               .IsRequired();
    }

    private static void ConfigureEmail(
        EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Email)
               .HasConversion(
                   x => x.Value,
                   v => Email.Create(v).Value)
               .HasMaxLength(Email.MaxLength)
               .IsRequired();

        builder.HasIndex(x => x.Email)
               .IsUnique();
    }

    private static void ConfigurePhoneNumber(
    EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(x => x.PhoneNumber, phone =>
        {
            phone.Property(x => x.CountryCode)
                 .HasMaxLength(5)
                 .IsRequired();

            phone.Property(x => x.Number)
                 .HasMaxLength(15)
                 .IsRequired();
        });
    }

    private static void ConfigureRoles(
        EntityTypeBuilder<User> builder)
    {
        builder.HasMany<Role>("_roles")
               .WithMany();
    }
}
