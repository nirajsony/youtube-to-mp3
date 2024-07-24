import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherComponentComponent } from './weather-component.component';

describe('WeatherComponentComponent', () => {
  let component: WeatherComponentComponent;
  let fixture: ComponentFixture<WeatherComponentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WeatherComponentComponent]
    });
    fixture = TestBed.createComponent(WeatherComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
