using SmartKart.Identity.Domain.Primitives;
using SmartKart.Identity.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartKart.Identity.Domain.Entities.UserEntities.ValueObjects
{
    public sealed class PhoneNumber : ValueObject
    {
        private PhoneNumber(
            string countryCode,
            string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        public string CountryCode { get; }

        public string Number { get; }

        public string FullNumber =>
            $"{CountryCode}{Number}";

        public static Result<PhoneNumber> Create(
            string countryCode,
            string number)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                return Result.Failure<PhoneNumber>(
                    UserErrors.PhoneNumber.CountryCodeRequired);
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                return Result.Failure<PhoneNumber>(
                    UserErrors.PhoneNumber.NumberRequired);
            }

            return new PhoneNumber(
                countryCode,
                number);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return CountryCode;
            yield return Number;
        }
    }
}
