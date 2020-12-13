import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseApiService } from 'src/app/shared-app/services/base-auth.service';
import { PacketDetailResponse, PaginatedPacketsResponse, UpdatedPacketResponse } from '../models/packet.models';

@Injectable({
  providedIn: 'root'
})
export class PacketsService extends BaseApiService  {

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getPacketList(page: number, pageSize: number): Observable<PaginatedPacketsResponse> {
    return this.get<PaginatedPacketsResponse>(`packet?page=${page}&pageSize=${pageSize}`);
  }

  public getPacketDetails(packetUid: string): Observable<PacketDetailResponse> {
    return this.get<PacketDetailResponse>(`packet/${packetUid}`);
  }

  public checkForPacketUpdate(packetUid: string, version: number, country: string, versionFrom: number): Observable<UpdatedPacketResponse> {
    return this.get<UpdatedPacketResponse>(`packet/${packetUid}/version/${version}?country=${country}&versionFrom=${versionFrom}`);
  }
}
