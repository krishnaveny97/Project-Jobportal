import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LandingComponent } from './component/landing/landing.component';
import { LoginSignUpComponent } from './component/login-sign-up/login-sign-up.component';
import { SetPasswordComponent } from './component/set-password/set-password.component';
import { SpinnerComponent } from './component/spinner/spinner.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon'; // Import MatIconModule
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button'; // If you're using buttons
import { MatDialogModule } from '@angular/material/dialog';
import { SetPasswordDialogueComponent } from './component/set-password-dialogue/set-password-dialogue.component';





@NgModule({
  declarations: [
   
    LandingComponent,
    LoginSignUpComponent,
    SetPasswordComponent,
    SpinnerComponent,
    SetPasswordDialogueComponent
   
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule ,
    ReactiveFormsModule,FormsModule,
    MatButtonModule,
    MatDialogModule 

    
    
  ]
})
export class AuthenticationModule { }
