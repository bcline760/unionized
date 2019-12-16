import { TestBed } from '@angular/core/testing';

import { UnionizedService } from './unionized.service';

describe('UnionizedService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UnionizedService = TestBed.get(UnionizedService);
    expect(service).toBeTruthy();
  });
});
