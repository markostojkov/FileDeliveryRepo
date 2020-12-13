import { NgModule } from '@angular/core';

import { PacketListComponent } from './components/packet-list/packet-list.component';
import { PacketDetailComponent } from './components/packet-detail/packet-detail.component';
import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { PacketsService } from './services/packets.service';
import { ROUTES } from './packets.routes';


@NgModule({
  declarations: [PacketListComponent, PacketDetailComponent],
  imports: [
    SharedAppModule,
    ROUTES
  ],
  providers: [PacketsService]
})
export class PacketsModule { }
