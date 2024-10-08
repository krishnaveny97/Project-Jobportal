import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './component/landing/landing.component';
import { LoginSignUpComponent } from './component/login-sign-up/login-sign-up.component';
import { SetPasswordComponent } from './component/set-password/set-password.component';
import { AuthGuard } from '../guards/guards.guard';

const routes: Routes = [
  {path:'landing',component:LandingComponent},
  {path:'',redirectTo:'landing',pathMatch:'full'},
  {path:'Login-Signup',component:LoginSignUpComponent},
  {path:'set-password',component:SetPasswordComponent} ,
 // {path:'job-seeker',loadChildren:()=>import('../job-seeker/job-seeker.module').then(j=>j.JobSeekerModule),canActivate: [AuthGuard]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
