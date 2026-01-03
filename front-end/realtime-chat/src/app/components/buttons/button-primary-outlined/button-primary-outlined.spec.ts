import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonPrimaryOutlined } from './button-primary-outlined';

describe('ButtonPrimaryOutlined', () => {
  let component: ButtonPrimaryOutlined;
  let fixture: ComponentFixture<ButtonPrimaryOutlined>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ButtonPrimaryOutlined]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonPrimaryOutlined);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
