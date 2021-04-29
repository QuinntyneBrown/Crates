import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DigitalAssetUrlInputComponent } from './digital-asset-url-input.component';

describe('DigitalAssetUrlInputComponent', () => {
  let component: DigitalAssetUrlInputComponent;
  let fixture: ComponentFixture<DigitalAssetUrlInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DigitalAssetUrlInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DigitalAssetUrlInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
