
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../authentication/service/auth.service'; // Example: AuthService handles authentication
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (this.authService.isLoggedIn()) {
      console.log('User is logged in');
      return true;
    }
     else {
      console.log('User is not logged in, redirecting to Login-Signup');
      // Redirect to login page or some other page
      this.router.navigate(['/Login-Signup']);
      return false;
    }
  }
}

