import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { PaginatedPacketsResponse } from '../../models/packet.models';
import { PacketsService } from '../../services/packets.service';

@Component({
  selector: 'app-packet-list',
  templateUrl: './packet-list.component.html',
  styleUrls: ['./packet-list.component.css']
})
export class PacketListComponent implements OnInit {

  packets: PaginatedPacketsResponse;
  working = true;

  constructor(private packetsService: PacketsService, private router: Router) { }

  ngOnInit(): void {
    this.packetsService.getPacketList(1, 10).subscribe(
      res => {
      this.packets = res;
      this.working = false;
      },
      err => this.working = false
    );
  }

  public routeToPacketDetail(uid: string): void {
    this.router.navigateByUrl(`packets/${uid}`);
  }
}
