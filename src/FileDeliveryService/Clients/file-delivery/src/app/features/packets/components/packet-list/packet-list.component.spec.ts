import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacketListComponent } from './packet-list.component';

describe('PacketListComponent', () => {
  let component: PacketListComponent;
  let fixture: ComponentFixture<PacketListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacketListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacketListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
