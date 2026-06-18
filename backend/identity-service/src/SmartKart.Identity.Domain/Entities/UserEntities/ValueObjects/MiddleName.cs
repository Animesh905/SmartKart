using SmartKart.Identity.Domain.Primitives;
using SmartKart.Identity.Shared.Result;

namespace SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;

public sealed class MiddleName : ValueObject
{
    public const int MaxLength = 50;
    private MiddleName(string value) => this.Value = value;
    public string Value { get; }
    public static Result<MiddleName> Create(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
        {
            return Result.Failure<MiddleName>(UserErrors.MiddleName.Empty);
        }

        if (middleName.Length > MaxLength)
        {
            return Result.Failure<MiddleName>(UserErrors.MiddleName.TooLong);
        }

        return new MiddleName(middleName);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
