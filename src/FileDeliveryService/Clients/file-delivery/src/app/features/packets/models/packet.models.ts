export class PaginatedPacketsResponse {
  count: number;
  currentPage: number;
  paginatedPackets: PaginatedPackets[];
}

class PaginatedPackets {
  uid: string;
  name: string;
  logoUrl: string;
}

export class UpdatedPacketResponse {
  packetCurrentVersion: string;
  packetPreviousVersion: string;
}

export class PacketDetailResponse {
  uid: string;
  name: string;
  logoUrl: string;
  versionDetails: VersionDetailResponse[];
}

export class VersionDetailResponse {
  versionCode: string;
  versionNumber: number;
}
