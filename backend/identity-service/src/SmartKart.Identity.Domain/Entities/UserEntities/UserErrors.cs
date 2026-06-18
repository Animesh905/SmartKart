using SmartKart.Identity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartKart.Identity.Domain.Entities.UserEntities
{
    public static class UserErrors
    {
        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name is empty");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                "First name is too long");
        }

        public static class MiddleName
        {
            public static readonly Error Empty = new(
                "MiddleName.Empty",
                "Middle name is empty");

            public static readonly Error TooLong = new(
                "MiddleName.TooLong",
                "Middle name is too long");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "Last name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "Last name is too long");
        }

        public static class Email
        {
            public static readonly Error Empty = new(
                "Email.Empty",
                "Email is empty");

            public static readonly Error TooLong = new(
                "Email.TooLong",
                "Email is too long");

            public static readonly Error InvalidFormat = new(
                "Email.InvalidFormat",
                "Email has an invalid format");
        }
    }
}
