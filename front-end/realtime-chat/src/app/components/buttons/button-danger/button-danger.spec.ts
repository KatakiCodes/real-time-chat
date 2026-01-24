import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonDanger } from './button-danger';

describe('ButtonDanger', () => {
  let component: ButtonDanger;
  let fixture: ComponentFixture<ButtonDanger>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ButtonDanger]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonDanger);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
