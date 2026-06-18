using SmartKart.Identity.Domain.Primitives;
using SmartKart.Identity.Shared.Result;

namespace SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 50;
    private LastName(string value) => this.Value = value;
    public string Value { get; }
    public static Result<LastName> Create(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<LastName>(UserErrors.LastName.Empty);
        }

        if (lastName.Length > MaxLength)
        {
            return Result.Failure<LastName>(UserErrors.LastName.TooLong);
        }

        return new LastName(lastName);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
