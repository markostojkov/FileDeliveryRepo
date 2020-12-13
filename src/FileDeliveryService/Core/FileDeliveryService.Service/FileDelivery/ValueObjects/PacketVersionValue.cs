using System.Collections.Generic;

using FileDeliveryService.Common.Error;
using FileDeliveryService.Common.ValueObjects;

namespace FileDeliveryService.Service.FileDelivery.ValueObjects
{
    public sealed class PacketVersionValue : BaseValueObject
    {
        private PacketVersionValue(int versionCode)
        {
            VersionCode = versionCode;
        }

        public int VersionCode { get; set; }

        public static PacketVersionValue Create(int versionCode)
        {
            var errorResponse = new ErrorResponse();

            if (versionCode < 0)
            {
                errorResponse.AddError(ErrorCodes.VersionCodeInvalid);
            }

            errorResponse.ThrowIfErrors();
            return new PacketVersionValue(versionCode);
        }

        public static PacketVersionValue CheckIfVersionToUpdateIsNotDowngrade(int currentVersionCode, int versionCode)
        {
            var errorResponse = new ErrorResponse();

            if (currentVersionCode >= versionCode)
            {
                errorResponse.AddError(ErrorCodes.CantDowngradePackageVersion);
            }

            errorResponse.ThrowIfErrors();
            return new PacketVersionValue(versionCode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return VersionCode;
        }
    }
}
