import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobSeekerRoutingModule }  from './job-seeker-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CommonSidebarComponent } from './components/common-sidebar/common-sidebar.component';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MyprofileComponent } from './components/myprofile/myprofile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


// Angular Material Modules

import { MatTabsModule } from '@angular/material/tabs'; // Added
import { MatFormFieldModule } from '@angular/material/form-field'; // Added
import { MatInputModule } from '@angular/material/input'; // Added




@NgModule({
  declarations: [
    DashboardComponent,
    CommonSidebarComponent,
    MyprofileComponent
  ],
  imports: [
    CommonModule,
    JobSeekerRoutingModule,
   // BrowserAnimationsModule, // Required for Angular Material animations
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatMenuModule,
    MatDividerModule,
    MatButtonModule,  // Since you are using `mat-menu-item` and buttons
    FormsModule,
    ReactiveFormsModule,
    MatTabsModule,         // Added
    MatFormFieldModule,    // Added
    MatInputModule
  ]
})
export class JobSeekerModule { }
