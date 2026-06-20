using SmartKart.Identity.Domain.Primitives;

namespace SmartKart.Identity.Domain.Entities.PermissionEntities;

public sealed class Permission : Entity
{
    private Permission(
        Guid id,
        string code,
        string name)
        : base(id)
    {
        Code = code;
        Name = name;
    }

    private Permission()
    {
    }

    public string Code { get; private set; }

    public string Name { get; private set; }

    public static Permission Create(
        Guid id,
        string code,
        string name)
    {
        return new Permission(
            id,
            code,
            name);
    }
}
