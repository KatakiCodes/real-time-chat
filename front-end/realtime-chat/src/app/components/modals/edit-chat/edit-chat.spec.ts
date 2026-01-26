import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditChat } from './edit-chat';

describe('EditChat', () => {
  let component: EditChat;
  let fixture: ComponentFixture<EditChat>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditChat]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditChat);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
