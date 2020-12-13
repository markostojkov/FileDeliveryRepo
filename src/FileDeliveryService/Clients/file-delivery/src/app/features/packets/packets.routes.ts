import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PacketDetailComponent } from './components/packet-detail/packet-detail.component';
import { PacketListComponent } from './components/packet-list/packet-list.component';
import { PacketsModule } from './packets.module';

const routes: Routes = [
  {
    path: 'packets',
    children: [
      {
        path: ':uid',
        component: PacketDetailComponent
      },
      {
        path: '',
        component: PacketListComponent
      }
    ]
  }
];

export const ROUTES: ModuleWithProviders<PacketsModule> = RouterModule.forChild(routes);
