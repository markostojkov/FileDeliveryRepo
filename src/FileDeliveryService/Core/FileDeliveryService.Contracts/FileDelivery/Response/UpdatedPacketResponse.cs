namespace FileDeliveryService.Contracts.FileDelivery.Response
{
    public class UpdatedPacketResponse
    {
        public UpdatedPacketResponse(string packetCurrentVersion, string packetPreviousVersion)
        {
            PacketCurrentVersion = packetCurrentVersion;
            PacketPreviousVersion = packetPreviousVersion;
        }

        public string PacketCurrentVersion { get; }

        public string PacketPreviousVersion { get; }
    }
}
