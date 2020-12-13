import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PacketDetailResponse } from '../../models/packet.models';
import { PacketsService } from '../../services/packets.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-packet-detail',
  templateUrl: './packet-detail.component.html',
  styleUrls: ['./packet-detail.component.css']
})
export class PacketDetailComponent implements OnInit {

  packet: PacketDetailResponse;
  packetUid: string;

  working = true;

  // request parameters
  country = 'AF';
  currentVersion = 1;
  newVersion = 1;

  constructor(private packetsService: PacketsService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.packetUid = this.route.snapshot.params.uid;
    this.packetsService.getPacketDetails(this.packetUid).subscribe(
      res => {
      this.packet = res;
      this.working = false;
      },
      err => {
        this.working = false;
      }
    );
  }

  public countryIsChanged(country: string): void {
    this.country = country;
  }

  public currentVersionIsChanged(currentVersion: number): void {
    this.currentVersion = currentVersion;
  }

  public newVersionIsChanged(newVersion: number): void {
    this.newVersion = newVersion;
  }

  public checkForUpdate(): void {
    this.packetsService.checkForPacketUpdate(this.packetUid, this.newVersion, this.country, this.currentVersion).subscribe(
      () => this.toastr.success('Successfull update'));
  }
}
