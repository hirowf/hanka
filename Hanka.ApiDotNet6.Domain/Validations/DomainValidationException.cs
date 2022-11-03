using System;
namespace Hanka.ApiDotNet6.Domain.Validations
{
    /* Herdando Exception */
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}

