import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatsLayout } from './chats-layout';

describe('ChatsLayout', () => {
  let component: ChatsLayout;
  let fixture: ComponentFixture<ChatsLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChatsLayout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatsLayout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
