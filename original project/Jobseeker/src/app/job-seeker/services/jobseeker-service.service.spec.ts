import { TestBed } from '@angular/core/testing';

import { JobseekerServiceService } from './jobseeker-service.service';

describe('JobseekerServiceService', () => {
  let service: JobseekerServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobseekerServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
