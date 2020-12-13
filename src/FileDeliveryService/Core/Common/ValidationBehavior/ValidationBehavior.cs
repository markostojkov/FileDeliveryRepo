using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using FluentValidation;
using ValidationContext = FluentValidation.ValidationContext;

namespace FileDeliveryService.Common.ValidationBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var errorResponse = new Error.ErrorResponse();

            foreach (var validation in _validators)
            {
                var validationResponse = await validation.ValidateAsync(context);

                foreach (var error in validationResponse.Errors)
                {
                    errorResponse.AddError(error.ErrorMessage);
                }
            }

            errorResponse.ThrowIfErrors();

            return await next();

        }
    }
}
