using SmartKart.Identity.Domain.Entities.RoleEntities;
using SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;
using SmartKart.Identity.Domain.Primitives;

namespace SmartKart.Identity.Domain.Entities.UserEntities;

public sealed class User : AggregateRoot
{
    private readonly List<Role> _roles = [];

    private User(
        Guid id,
        FirstName firstName,
        MiddleName middleName,
        LastName lastName,
        Email email,
        PhoneNumber phoneNumber,
        bool isActive)
        : base(id)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        IsEmailVerified = false;
    }

    private User()
    {
    }

    public FirstName FirstName { get; private set; }

    public MiddleName MiddleName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsEmailVerified { get; private set; }

    public IReadOnlyCollection<Role> Roles =>
        _roles.AsReadOnly();

    public static User Create(
        Guid id,
        FirstName firstName,
        MiddleName middleName,
        LastName lastName,
        Email email,
        PhoneNumber phoneNumber)
    {
        var user = new User(
            id,
            firstName,
            middleName,
            lastName,
            email,
            phoneNumber,
            true);

        //user.RaiseDomainEvent(
        //    new UserRegisteredDomainEvent(user.Id));

        return user;
    }

    public void VerifyEmail()
    {
        IsEmailVerified = true;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void AssignRole(Role role)
    {
        if (_roles.Any(x => x.Id == role.Id))
        {
            return;
        }

        _roles.Add(role);
    }

    public void RemoveRole(Guid roleId)
    {
        var role = _roles.FirstOrDefault(x => x.Id == roleId);

        if (role is null)
        {
            return;
        }

        _roles.Remove(role);
    }
}