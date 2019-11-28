import { TestBed } from '@angular/core/testing';

import { NetworkLogService } from './network-log.service';

describe('NetworkLogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NetworkLogService = TestBed.get(NetworkLogService);
    expect(service).toBeTruthy();
  });
});
