import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CommonSidebarComponent } from './components/common-sidebar/common-sidebar.component';
import { MyprofileComponent } from './components/myprofile/myprofile.component';

const routes: Routes = [
  {path:'',component:CommonSidebarComponent,
  children:[
    {path:'dashboard',component:DashboardComponent},
    {path:'',redirectTo:'dashboard',pathMatch:'full'},
    {path:'My-Profile',component:MyprofileComponent}

  ]}

 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobSeekerRoutingModule { }
