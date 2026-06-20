using SmartKart.Identity.Domain.Entities.PermissionEntities;
using SmartKart.Identity.Domain.Primitives;

namespace SmartKart.Identity.Domain.Entities.RoleEntities;

public sealed class Role : AggregateRoot
{
    private readonly List<Permission> _permissions = [];

    private Role(
        Guid id,
        string code,
        string name)
        : base(id)
    {
        Code = code;
        Name = name;
        IsActive = true;
    }

    private Role()
    {
    }

    public string Code { get; private set; }

    public string Name { get; private set; }

    public bool IsActive { get; private set; }

    public IReadOnlyCollection<Permission> Permissions =>
        _permissions.AsReadOnly();

    public static Role Create(
        Guid id,
        string code,
        string name)
    {
        return new Role(
            id,
            code,
            name);
    }

    public void AddPermission(
        Permission permission)
    {
        if (_permissions.Any(x => x.Id == permission.Id))
        {
            return;
        }

        _permissions.Add(permission);
    }

    public void RemovePermission(
        Guid permissionId)
    {
        var permission = _permissions
            .FirstOrDefault(x => x.Id == permissionId);

        if (permission is null)
        {
            return;
        }

        _permissions.Remove(permission);
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
