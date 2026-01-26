import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionResultModal } from './action-result-modal';

describe('ActionResultModal', () => {
  let component: ActionResultModal;
  let fixture: ComponentFixture<ActionResultModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActionResultModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActionResultModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
