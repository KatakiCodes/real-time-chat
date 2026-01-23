import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMember } from './add-member';

describe('AddMember', () => {
  let component: AddMember;
  let fixture: ComponentFixture<AddMember>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddMember]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMember);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
