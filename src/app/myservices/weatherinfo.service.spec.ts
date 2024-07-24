import { TestBed } from '@angular/core/testing';

import { WeatherinfoService } from './weatherinfo.service';

describe('WeatherinfoService', () => {
  let service: WeatherinfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeatherinfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
