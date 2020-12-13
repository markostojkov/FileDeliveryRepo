import { TestBed } from '@angular/core/testing';

import { PacketsService } from './packets.service';

describe('PacketsService', () => {
  let service: PacketsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PacketsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
