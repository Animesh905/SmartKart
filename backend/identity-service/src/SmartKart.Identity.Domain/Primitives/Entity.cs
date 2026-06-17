namespace SmartKart.Identity.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }

    protected Entity(Guid id) => Id = id;

    protected Entity()
    {

    }
    public static bool operator ==(Entity? first, Entity? second)
    {
        if (ReferenceEquals(first, second))
            return true;

        if (first is null || second is null)
            return false;

        return first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second) => !(first == second);

    public bool Equals(Entity? other)
    {
        if (other is null || other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is null || obj.GetType() != GetType())
            return false;

        return obj is Entity entity && Equals(entity);
    }

    public override int GetHashCode() => HashCode.Combine(Id);
}
