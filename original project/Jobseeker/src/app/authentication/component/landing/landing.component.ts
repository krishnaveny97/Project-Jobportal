import { Component,ElementRef } from '@angular/core';
import { Router ,ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent {
  constructor(private router:Router,private rout:ActivatedRoute,private elementRef:ElementRef){}

  loginRegister(){
    this.router.navigate(['Login-Signup'])
  }

  toggleMenu(){
    this.elementRef.nativeElement.querySelector('#navbar').classList.toggle('navbar-mobile');
    this.elementRef.nativeElement.classList.toggle('bi-x');
  }
  isActive(path: string):boolean{
    return this.router.url.split('#')[1]===path;
  }


}
