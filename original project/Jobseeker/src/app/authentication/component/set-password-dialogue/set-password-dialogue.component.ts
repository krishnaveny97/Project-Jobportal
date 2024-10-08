import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SetPasswordDialogComponent } from 'src/app/src/app/authentication/component/set-password-dialog/set-password-dialog.component';

@Component({
  selector: 'app-set-password-dialogue',
  templateUrl: './set-password-dialogue.component.html',
  styleUrls: ['./set-password-dialogue.component.css']
})
export class SetPasswordDialogueComponent {
  constructor(
    private dialogRef: MatDialogRef<SetPasswordDialogComponent>,
    private router: Router,
   
  ) {}
  redirectToLogin(): void {
    this.dialogRef.close();
    this.router.navigate(['/Login-Signup']); // Redirect to login page
  }

}
