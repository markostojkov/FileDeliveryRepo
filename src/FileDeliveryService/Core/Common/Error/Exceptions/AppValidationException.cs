using System;

namespace FileDeliveryService.Common.Error.Exceptions
{
    public sealed class AppValidationException : Exception
    {
        public AppValidationException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }

        public ErrorResponse ErrorResponse { get; }

    }
}
