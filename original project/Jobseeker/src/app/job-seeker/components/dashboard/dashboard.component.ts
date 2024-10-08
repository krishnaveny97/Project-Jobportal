import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  cards=[
    {head:'Interview Schedule',count:86,icon:'calendar2-check',color:'#E91E63'},
    {head:'Application Sent',count:75,icon:'briefcase-fill',color:'#009688'},
    {head:'Profile Viewed',count:103,icon:'person-fill',color:'#607D8B'},
    {head:'Unread Messages',count:10,icon:'envelope-fill',color:'#FF5722'},
   ]

}
