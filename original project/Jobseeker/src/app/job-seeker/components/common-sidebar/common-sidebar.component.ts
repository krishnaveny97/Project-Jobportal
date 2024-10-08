import { Component,ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { JobseekerServiceService } from '../../services/jobseeker-service.service';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { delay, filter } from 'rxjs/operators';
import { untilDestroyed } from '@ngneat/until-destroy';

@Component({
  selector: 'app-common-sidebar',
  templateUrl: './common-sidebar.component.html',
  styleUrls: ['./common-sidebar.component.css']
})
export class CommonSidebarComponent {
  constructor(private observer: BreakpointObserver,private router:Router,private service:JobseekerServiceService){}
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  profileName:any;

  ngAfterViewInit() {
    this.observer
      .observe(['(max-width: 800px)'])
      .pipe(delay(1), untilDestroyed(this))
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });

    this.router.events
      .pipe(
        untilDestroyed(this),
        filter((e) => e instanceof NavigationEnd)
      )
      .subscribe(() => {
        if (this.sidenav.mode === 'over') {
          this.sidenav.close();
        }
      });
  }

  ngOnInit(){
    
    }
    logout():void{
      this.service.logout();
  

  }

}
