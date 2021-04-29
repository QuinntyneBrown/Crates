import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppleMusicButtonComponent } from './apple-music-button.component';

describe('AppleMusicButtonComponent', () => {
  let component: AppleMusicButtonComponent;
  let fixture: ComponentFixture<AppleMusicButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppleMusicButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppleMusicButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
