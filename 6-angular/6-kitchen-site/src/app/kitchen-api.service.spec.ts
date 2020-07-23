import { TestBed } from '@angular/core/testing';

import { KitchenApiService } from './kitchen-api.service';

describe('KitchenApiService', () => {
  let service: KitchenApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KitchenApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
