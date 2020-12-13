namespace FileDeliveryService.Contracts.FileDelivery.Response
{
    public class VersionDetailResponse
    {
        public VersionDetailResponse(string versionCode, int versionNumber)
        {
            VersionCode = versionCode;
            VersionNumber = versionNumber;
        }

        public VersionDetailResponse()
        {
        }

        public string VersionCode { get; }

        public int VersionNumber { get; }
    }
}
