import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacketDetailComponent } from './packet-detail.component';

describe('PacketDetailComponent', () => {
  let component: PacketDetailComponent;
  let fixture: ComponentFixture<PacketDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacketDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacketDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
