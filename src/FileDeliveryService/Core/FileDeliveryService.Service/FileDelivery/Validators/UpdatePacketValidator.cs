using FluentValidation;

using FileDeliveryService.Persistence.Repositories.Interfaces;
using FileDeliveryService.Service.FileDelivery.Commands;
using FileDeliveryService.Common.Error;

namespace FileDeliveryService.Service.FileDelivery.Validators
{
    public class UpdatePacketValidator : AbstractValidator<UpdatePacket.Command>
    {
        public UpdatePacketValidator(IPacketRepository packetRepository, IVersionRepository versionRepository)
        {
            RuleFor(x => x.PacketUid).MustAsync(async (x, cancellation) => {
                return await packetRepository.PacketWithUidExists(x);
            }).WithMessage(ErrorCodes.PacketDoesNotExist);

            RuleFor(x => new { currentVersion = x.CurrentVersion.VersionCode, packetUid = x.PacketUid }).MustAsync(async (x, cancellation) => {
                if (x.currentVersion == 0) return true;

                return await versionRepository.PacketVersionExists(x.packetUid, x.currentVersion);
            }).WithMessage(ErrorCodes.CurrentVersionDoesNotExist);

            RuleFor(x => new { currentVersion = x.PacketVersion.VersionCode, packetUid = x.PacketUid }).MustAsync(async (x, cancellation) => {
                return await versionRepository.PacketVersionExists(x.packetUid, x.currentVersion);
            }).WithMessage(ErrorCodes.VersionDoesNotExist);
        }
    }
}
