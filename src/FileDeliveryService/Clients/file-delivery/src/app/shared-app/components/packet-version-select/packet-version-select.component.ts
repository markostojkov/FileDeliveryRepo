import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { VersionDto } from 'src/app/features/packets/models/version.dto';

@Component({
  selector: 'app-packet-version-select',
  templateUrl: './packet-version-select.component.html',
  styleUrls: ['./packet-version-select.component.css']
})
export class PacketVersionSelectComponent implements OnInit {

  @Input() packetVersionText: string;
  @Input() packetVersions: VersionDto[];
  @Output() packetChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  public onChange(event: number): void {
    this.packetChanged.emit(event);
  }
}
