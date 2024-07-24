import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YouTubeToMp3Component } from './you-tube-to-mp3.component';


describe('YouTubeToMp3Component', () => {
  let component: YouTubeToMp3Component;
  let fixture: ComponentFixture<YouTubeToMp3Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [YouTubeToMp3Component]
    });
    fixture = TestBed.createComponent(YouTubeToMp3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
