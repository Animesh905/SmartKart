using Microsoft.IdentityModel.Tokens;
using SmartKart.Identity.Domain.Primitives;
using SmartKart.Identity.Shared.Result;
using System.Net.Mail;
using static SmartKart.Identity.Domain.Entities.UserEntities.UserErrors;

namespace SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects;

public sealed class Email : ValueObject
{
    public const int MaxLength = 50; 
    private Email(string value) => this.Value = value;
    public string Value { get; }
    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Email>(UserErrors.Email.Empty);
        }

        if (email.Length > MaxLength)
        {
            return Result.Failure<Email>(UserErrors.Email.TooLong);
        }

        if (!MailAddress.TryCreate(email, out _))
        {
            return Result.Failure<Email>(UserErrors.Email.InvalidFormat);
        }

        return new Email(email);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
