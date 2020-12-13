namespace FileDeliveryService.Common.Error
{
    public static class ErrorCodes
    {
        public const string PagingValuePageMustBePositive = "PAGING_VALUE_PAGE_MUST_BE_POSITIVE";

        // Version
        public const string VersionValueLength = "VERSION_VALUE_LENGTH";
        public const string VersionValueVersionParse = "VERSION_VALUE_VERSION_PARSE";
        public const string VersionCodeInvalid = "VERSION_CODE_INVALID";
        public const string VersionDoesNotExist = "VERSION_DOES_NOT_EXIST";
        public const string CurrentVersionDoesNotExist = "CURRENT_VERSION_DOES_NOT_EXIST";
        public const string CantDowngradePackageVersion = "CANT_DOWNGRADE_PACKAGE_VERSION";

        // Country code
        public const string CountryCodeValidationEmpty = "COUNTRY_CODE_VALIDATION_EMPTY";
        public const string CountryCodeValidationLength = "COUNTRY_CODE_VALIDATION_LENGTH";
        public const string CountryCodeInvalidCountry = "COUNTRY_CODE_INVALID_COUNTRY";

        // Packet
        public const string PacketDoesNotExist = "PACKET_DOES_NOT_EXIST";
        public const string PacketNotAvaliableInCountry = "PACKET_NOT_AVALIABLE_IN_COUNTRY";
        public const string PacketNotReleased = "PACKET_NOT_RELEASED";
        public const string PacketVersionMultiStage = "PACKET_VERSION_MULTI_STAGE";
    }
}
