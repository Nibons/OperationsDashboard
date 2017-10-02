import { TestBed, inject } from '@angular/core/testing';

import { ServermappingService } from './servermapping.service';

describe('ServermappingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServermappingService]
    });
  });

  it('should be created', inject([ServermappingService], (service: ServermappingService) => {
    expect(service).toBeTruthy();
  }));
});
