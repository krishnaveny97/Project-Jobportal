import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetPasswordDialogueComponent } from './set-password-dialogue.component';

describe('SetPasswordDialogueComponent', () => {
  let component: SetPasswordDialogueComponent;
  let fixture: ComponentFixture<SetPasswordDialogueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SetPasswordDialogueComponent]
    });
    fixture = TestBed.createComponent(SetPasswordDialogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
