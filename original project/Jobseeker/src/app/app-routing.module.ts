import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/guards.guard';

const routes: Routes = [
  {path:'',loadChildren:()=>import('../app/authentication/authentication.module').then(m=>m.AuthenticationModule)},
   {path:'job-seeker',loadChildren:()=>import('../app/job-seeker/job-seeker.module').then(j=>j.JobSeekerModule),canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/Login-Signup' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
