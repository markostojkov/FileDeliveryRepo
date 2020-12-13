using System.Collections.Generic;
using Newtonsoft.Json;
using CountryData.Standard;

using FileDeliveryService.Common.Error;
using FileDeliveryService.Common.ValueObjects;

namespace FileDeliveryService.Service.FileDelivery.ValueObjects
{
    public sealed class CountryCodeValue : BaseValueObject
    {
        private const int CountryCodeLength = 2;

        public string Value { get; }

        [JsonConstructor]
        private CountryCodeValue(string value)
        {
            Value = value;
        }

        public static CountryCodeValue Create(string value)
        {
            value = value.ToLower().Trim();
            var errorResponse = new ErrorResponse();

            if (value.Length < 1)
            {
                errorResponse.AddError(ErrorCodes.CountryCodeValidationEmpty);
            }

            if (value.Length != CountryCodeLength)
            {
                errorResponse.AddError(ErrorCodes.CountryCodeValidationLength);
            }

            if (new CountryHelper().GetCountry(value) == null)
            {
                errorResponse.AddError(ErrorCodes.CountryCodeInvalidCountry);    
            }

            errorResponse.ThrowIfErrors();
            return new CountryCodeValue(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
