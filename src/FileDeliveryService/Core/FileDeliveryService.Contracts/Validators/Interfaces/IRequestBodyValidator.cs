using FileDeliveryService.Common.Error;

namespace FileDeliveryService.Contracts.Validators.Interfaces
{
    public interface IRequestBodyValidator
    {
        ErrorResponse Validate();
    }
}