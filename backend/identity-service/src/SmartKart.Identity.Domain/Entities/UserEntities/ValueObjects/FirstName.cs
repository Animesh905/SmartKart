using SmartKart.Identity.Domain.Primitives;
using SmartKart.Identity.Shared.Result;

namespace SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;
    private FirstName(string value) => this.Value = value;
    public string Value { get; }
    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FirstName>(UserErrors.FirstName.Empty);
        }

        if (firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(UserErrors.FirstName.TooLong);
        }

        return new FirstName(firstName);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
