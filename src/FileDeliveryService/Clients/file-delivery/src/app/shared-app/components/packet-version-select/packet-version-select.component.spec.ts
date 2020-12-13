import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacketVersionSelectComponent } from './packet-version-select.component';

describe('PacketVersionSelectComponent', () => {
  let component: PacketVersionSelectComponent;
  let fixture: ComponentFixture<PacketVersionSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacketVersionSelectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacketVersionSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
