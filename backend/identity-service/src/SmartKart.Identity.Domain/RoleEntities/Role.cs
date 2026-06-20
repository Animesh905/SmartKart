using SmartKart.Identity.Domain.Primitives;

namespace SmartKart.Identity.Domain.RoleEntities;

public sealed class Role : AggregateRoot
{
    private Role(
        Guid id,
        string code,
        string name)
        : base(id)
    {
        Code = code;
        Name = name;
    }

    private Role()
    {
    }

    public string Code { get; private set; }

    public string Name { get; private set; }

    public bool IsActive { get; private set; }

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
}
