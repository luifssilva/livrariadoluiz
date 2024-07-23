import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenderAddComponent } from './gender-add.component';

describe('GenderAddComponent', () => {
  let component: GenderAddComponent;
  let fixture: ComponentFixture<GenderAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GenderAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenderAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
