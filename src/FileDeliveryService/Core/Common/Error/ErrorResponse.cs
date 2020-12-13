using System.Collections.Generic;
using System.Net;

using FileDeliveryService.Common.Error.Exceptions;

namespace FileDeliveryService.Common.Error
{
    public class ErrorResponse
    {
        public List<string> Errors { get; }

        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.BadRequest;

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorResponse(string error) : this()
        {
            Errors.Add(error);
        }

        public ErrorResponse()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void ThrowIfErrors()
        {
            if (HasErrors())
            {
                throw new AppValidationException(this);
            }
        }

        private bool HasErrors()
        {
            return Errors.Count > 0;
        }
    }
}
