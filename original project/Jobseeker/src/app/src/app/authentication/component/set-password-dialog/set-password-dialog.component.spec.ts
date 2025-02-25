import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetPasswordDialogComponent } from './set-password-dialog.component';

describe('SetPasswordDialogComponent', () => {
  let component: SetPasswordDialogComponent;
  let fixture: ComponentFixture<SetPasswordDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SetPasswordDialogComponent]
    });
    fixture = TestBed.createComponent(SetPasswordDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
