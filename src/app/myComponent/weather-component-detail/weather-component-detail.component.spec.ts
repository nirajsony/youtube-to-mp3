import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherComponentDetailComponent } from './weather-component-detail.component';

describe('WeatherComponentDetailComponent', () => {
  let component: WeatherComponentDetailComponent;
  let fixture: ComponentFixture<WeatherComponentDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WeatherComponentDetailComponent]
    });
    fixture = TestBed.createComponent(WeatherComponentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
