import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IntroduceLayout } from './introduce-layout';

describe('IntroduceLayout', () => {
  let component: IntroduceLayout;
  let fixture: ComponentFixture<IntroduceLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IntroduceLayout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IntroduceLayout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
